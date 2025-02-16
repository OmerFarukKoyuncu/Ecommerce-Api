using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using BLL.DTO.CustomerDto;
using BLL.DTO.Seller;
using BLL.Managers.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Customer")]
    [Authorize]
    public class CustomerProfileController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CustomerProfileController(IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _userManager = userManager;

        }
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {

            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);
                if (userId == null)
                {
                    return Unauthorized("Kullanıcı kimliği bulunamadı.");
                }

                var user = await _userManager.FindByIdAsync(userId.Value);
                if (user == null)
                {
                    return NotFound("Kullanıcı bulunamadı");
                }

                var userDto = _mapper.Map<CustomerDtoModel>(user);
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }


        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile(CustomerDtoModel customerDto)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);
                var user = await _userManager.FindByIdAsync(userId.Value);
                if (user == null)
                {
                    return NotFound("Kullanıcı bulunamadı");
                }
                user = _mapper.Map(customerDto, user);
                user.UserName = customerDto.UserName;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }

        }

    }
}
