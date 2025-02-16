using AutoMapper;
using BLL.DTO.UserDtos;
using BLL.DTO.UserDtosForAdmin;
using BLL.Managers.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ANK19_ETicaret.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserRoleManager _userRoleManager;

        public UserController(UserManager<User> userManager, IMapper mapper,IUserRoleManager userRoleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userRoleManager = userRoleManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDto userDto)
        {
            try
            {
                var checkMail = await _userManager.FindByEmailAsync(userDto.Email);
                if (checkMail != null)
                {
                    return BadRequest("Bu mail adresi zaten kayıtlı");
                }

                var user = _mapper.Map<User>(userDto);

                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return Ok(new { UserId = user.Id });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }
        }




        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userManager.Users.ToList();

            var userDto = _mapper.Map<List<GetAllUsersDto>>(users);

            return Ok(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersWithRoles()
        {
            var usersWithRolesDto = await _userRoleManager.GetAllUsersWithRoles();                 
            return Ok(usersWithRolesDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }

           
            var userDto = _mapper.Map<GetUserDto>(user);

            return Ok(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }

            
            var userDto = _mapper.Map<GetUserDto>(user);

            return Ok(userDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserByUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }         
            user.IsActive = false;
           
            var updatedUser = await _userManager.UpdateAsync(user);

            if (updatedUser.Succeeded)
            {              
                var userDto = _mapper.Map<GetUserDto>(user);
                return Ok(userDto);
            }     

            return BadRequest("Kullanıcı güncellenemedi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.IsActive = false;

            var updatedUser = await _userManager.UpdateAsync(user);

            if (updatedUser.Succeeded)
            {
                var userDto = _mapper.Map<GetUserDto>(user);
                return Ok(userDto);
            }
            return BadRequest("Kullanıcı güncellenemedi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserByUsername([FromQuery]  string username, [FromBody]  UpdateUserDto updateUserDto)
        {
            
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            
            _mapper.Map(updateUserDto, user);
            
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
               
                var userDto = _mapper.Map<GetUserDto>(user);
                return Ok(userDto);  
            }
      
            return BadRequest("Kullanıcı güncellenemedi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserById([FromQuery] string id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Eğer şifre null değilse, şifreyi güncelle
            if (!string.IsNullOrEmpty(updateUserDto.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, updateUserDto.Password);
                if (!result.Succeeded)
                {
                    return BadRequest("Şifre güncellenemedi.");
                }
            }

            // Diğer tüm özellikleri güncelle
            _mapper.Map(updateUserDto, user);

            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                var userDto = _mapper.Map<GetUserDto>(user);
                return Ok(userDto);
            }

            return BadRequest("Kullanıcı güncellenemedi.");
        }




    }
}
