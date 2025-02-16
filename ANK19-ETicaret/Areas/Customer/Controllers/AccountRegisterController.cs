using AutoMapper;
using BLL.DTO;
using BLL.DTO.CustomerRegisterDTO;
using BLL.DTO.Seller;
using BLL.Managers.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;

namespace ANK19_ETicaret.Areas.Customer.Controllers
{
    [Route ("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area ("Customer")]
    [Authorize]
    public class AccountRegisterController (IHttpContextAccessor _httpContextAccessor, IMapper _mapper, UserManager<User> _userManager, ISellerManager _sellerManager) : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CustomerRegister (CustomerRegisterDTO customerRegisterDTO)
        {

            var checkMail = await _userManager.FindByEmailAsync (customerRegisterDTO.Email);
            if (checkMail != null)
            {
                return BadRequest ("Bu mail adresi zaten kayıtlı");
            }

            var user = _mapper.Map<User> (customerRegisterDTO);

            var result = await _userManager.CreateAsync (user, customerRegisterDTO.Password);
            
            if (!result.Succeeded)
            {
                return BadRequest (result.Errors);
            }

            return Ok ();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SellerRegister (SellerRegisterDTO sellerRegisterDTO)
        {
            var seller = _sellerManager.GetSellerByID (sellerRegisterDTO.UserId);

            if (seller != null)
            {
                return BadRequest ("Zaten bir mağazanız var");
            }
            await _userManager.AddToRoleAsync (await _userManager.FindByIdAsync(sellerRegisterDTO.UserId),"Seller");
             _sellerManager.AddNewSeller ( _mapper.Map<SellerDTOModel> (sellerRegisterDTO));
            return Ok ();
        }

    }
}
