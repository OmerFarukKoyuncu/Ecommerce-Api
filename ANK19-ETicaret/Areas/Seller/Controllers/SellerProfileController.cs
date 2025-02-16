using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using BLL.DTO;
using BLL.DTO.Seller;
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ANK19_ETicaret.Areas.Seller.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Seller")]
    [Authorize]
    public class SellerProfileController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ISellerManager _sellerManager;

        public SellerProfileController(IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<User> userManager, ISellerManager sellerManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _userManager = userManager;
            _sellerManager = sellerManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);

                var user = await _userManager.FindByIdAsync(userId.Value);
                var sellerId = _sellerManager.GetIdByUserId(user.Id);
                var seller = _sellerManager.GetById(sellerId);
                if (user == null)
                {
                    return NotFound("Kullanıcı bulunamadı");
                }
                

                var sellerDto = _mapper.Map<SellerDTOModel>(seller);
                sellerDto.UserId = null;
                return Ok(sellerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProfile(SellerDTOModel sellerDto)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);
                var user = await _userManager.FindByIdAsync(userId.Value);

                if (user == null)
                {
                    return NotFound("Kullanıcı bulunamadı");
                }
                sellerDto.UserId = user.Id;
               
                 _sellerManager.Update(sellerDto);

               
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
