using BLL.DTO.UserDtosForAdmin;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface IUserRoleManager
    {
        Task<bool> AddRoleToUser(string userId, bool admin, bool user, bool seller);
        Task<List<GetUsersWithRolesDto>> GetAllUsersWithRoles();
    }
}
