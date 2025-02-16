using AutoMapper;
using BLL.DTO.UserDtosForAdmin;
using BLL.Managers.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    public class UserRoleManager : IUserRoleManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserRoleManager(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> AddRoleToUser(string userId, bool admin, bool user, bool seller)
        {
            var kullanıcı = await _userManager.FindByIdAsync(userId);
            if (kullanıcı != null)
            {
                var isInRoleAdmin = await _userManager.IsInRoleAsync(kullanıcı, "Admin");
                var isInRoleUser = await _userManager.IsInRoleAsync(kullanıcı, "User");
                var isInRoleSeller = await _userManager.IsInRoleAsync(kullanıcı, "Seller");

                if (admin != isInRoleAdmin)
                {
                    if (admin)
                        await _userManager.AddToRoleAsync(kullanıcı, "Admin");
                    else
                        await _userManager.RemoveFromRoleAsync(kullanıcı, "Admin");
                }

                if (user != isInRoleUser)
                {
                    if (user)
                        await _userManager.AddToRoleAsync(kullanıcı, "User");
                    else
                        await _userManager.RemoveFromRoleAsync(kullanıcı, "User");
                }

                if (seller != isInRoleSeller)
                {
                    if (seller)
                        await _userManager.AddToRoleAsync(kullanıcı, "Seller");
                    else
                        await _userManager.RemoveFromRoleAsync(kullanıcı, "Seller");
                }

                return true;
            }

            return false;
        }

        public async Task<List<GetUsersWithRolesDto>> GetAllUsersWithRoles()
        {

            var users = await _userManager.Users.ToListAsync();


            var usersDtosWithRoles = _mapper.Map<List<GetUsersWithRolesDto>>(users);


            foreach (var userDto in usersDtosWithRoles)
            {
                var user = users.First(u => u.Id == userDto.Id);
                var roles = await _userManager.GetRolesAsync(user);
                if (roles != null)
                {
                    userDto.RoleNames.AddRange(roles);

                }
            }

            return usersDtosWithRoles;
        }

    }
}
