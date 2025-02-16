using BLL.DTO.UserDtos;
using BLL.DTO.UserDtosForAdmin;
using BLL.Managers.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IUserRoleManager _userRoleManager;

        public RoleController(IUserRoleManager userRoleManager)
        {
            _userRoleManager = userRoleManager;
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUserRoles([FromQuery] string userId,bool admin,bool user, bool seller)
        {

          var result = await _userRoleManager.AddRoleToUser(userId, admin, user, seller);

            if (result == true)
            {
                return Ok(); 
            }

            return BadRequest("Kullanıcı güncellenemedi.");

          

        }
    }
}
