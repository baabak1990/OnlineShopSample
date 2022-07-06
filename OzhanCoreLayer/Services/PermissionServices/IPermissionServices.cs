using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OzhanCoreLayer.ViewModels.AdminVm;
using OzhanCoreLayer.ViewModels.PermissionsViewModels;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.Services.PermissionServices
{
    public interface IPermissionServices
    {
        #region RolesServices

        Task<List<Role>> GetAll();
        Task<bool> AddRoleToUser(long userId, List<byte> roles);
        Task<bool> EditRoleToUser(long userId, List<byte> roles);
        Task<byte> AddRole(RoleCreateVm vm);
        Task<RoleEditVM> FindRole(byte id);
        Task<RoleEditVM> EditRole(RoleEditVM model);


        #endregion

        #region PermissionServices

        Task<List<Permission>> GetAllPermissions();
        void AddPermissionToRole(byte roleId, List<int> permissions);
        Task<List<int>> GetSelectedRolesForEdit(byte roleID);
        void EditPermissionRoles(byte roleId, List<int> permissions);

        bool UserRoles(string username, int permissionId);
        #endregion

        #region UserConnections

        long getUserIdByUserName(string usemname);

        #endregion

    }
}