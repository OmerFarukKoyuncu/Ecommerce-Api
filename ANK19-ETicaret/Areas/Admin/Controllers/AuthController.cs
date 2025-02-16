using BLL.DTO.UserDtos;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ANK19_ETicaret.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public AuthController(IConfiguration configuration,UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            // Kullanıcı adı ve şifre doğrulaması
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");
            }

            // Kullanıcının giriş kaydını kontrol et
            var existingLogins = await _userManager.GetLoginsAsync(user);
            if (!existingLogins.Any(l => l.LoginProvider == "CustomProvider" && l.ProviderKey == user.Id))
            {
                // Eğer kayıt yoksa ekle
                var userLoginInfo = new UserLoginInfo("CustomProvider", user.Id, user.UserName);
                var loginResult = await _userManager.AddLoginAsync(user, userLoginInfo);

                if (!loginResult.Succeeded)
                {
                    return BadRequest("Kullanıcı giriş bilgileri kaydedilemedi.");
                }
            }

            // Kullanıcının rollerini al
            var roles = await _userManager.GetRolesAsync(user);

            // JWT token oluşturma için claim'leri hazırla
            var claims = new List<Claim>
    {
                //user.Id ve UserName aynı claim ile geliyordu,userName yerine UserId koyuldu.
        new Claim(JwtRegisteredClaimNames.Sub, user.Id), // Kullanıcı ID'si
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Benzersiz token ID
        new Claim(ClaimTypes.NameIdentifier, user.Id), // Kullanıcı ID'si
        new Claim(ClaimTypes.Email, user.Email ?? ""),
        new Claim(JwtRegisteredClaimNames.Sid,user.Id),// Email bilgisi
        //new Claim(ClaimTypes.NameIdentifier, user.Id), // Kullanıcı ID'si
        new Claim(ClaimTypes.Email, user.Email ?? ""), // Email bilgisi
    };

            // Kullanıcının rollerini claim'lere ekle
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            // JWT anahtarını al
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Token oluştur
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }



    }
}
