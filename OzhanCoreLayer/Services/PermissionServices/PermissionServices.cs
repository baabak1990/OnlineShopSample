using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzhanCoreLayer.Utilities.FIxer;
using OzhanCoreLayer.Utilities.Security;
using OzhanCoreLayer.Utilities.UniqNameGenerator;
using OzhanCoreLayer.ViewModels.AdminVm;
using OzhanCoreLayer.ViewModels.PermissionsViewModels;
using OzhanDataLayer.Context;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.Services.PermissionServices
{
    public class PermissionServices : IPermissionServices
    {
        #region Constructor

        private readonly OzhanContext _context;
        private readonly ISecurityService _security;

        public PermissionServices(OzhanContext context, ISecurityService security)
        {
            _context = context;
            _security = security;
        }

        #endregion

        #region RoleServices

        public async Task<List<Role>> GetAll()
        {
            return await _context.roles.ToListAsync();
        }


        public async Task<bool> AddRoleToUser(long userId, List<byte> roles)
        {
            foreach (byte roleidi in roles)
            {
                _context.UserRoles.Add(new UserRoles()
                {
                    User_Id = userId,
                    RoleP_Id = roleidi
                });
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> EditRoleToUser(long userId, List<byte> roles)
        {
            //Remove RolesFirst
            _context.UserRoles.Where(r => r.User_Id == userId).ToList().ForEach(r => _context.UserRoles.Remove(r));
            await AddRoleToUser(userId, roles);
            return true;

        }

        public async Task<byte> AddRole(RoleCreateVm vm)
        {
            //Todo: Id property does`nt filed auto so I had to Fill this manualy
            Role role = new Role();
            role.Title = vm.Title;
            await _context.AddAsync(role);
            await _context.SaveChangesAsync();
            return role.Id;
        }

        public async Task<RoleEditVM> FindRole(byte id)
        {
            var role = await _context.roles.FindAsync(id);
            return role.RoleModelToVm();
        }

        public async Task<RoleEditVM> EditRole(RoleEditVM model)
        {
            var role = await _context.roles.FindAsync(model.Id);
            role.Title = model.Title;
            _context.roles.Update(role);
            await _context.SaveChangesAsync();
            return role.RoleModelToVm();

        }

        #endregion

        #region PermissionServices

        public async Task<List<Permission>> GetAllPermissions()
        {
            return await _context.Permissions.ToListAsync();
        }

        public void AddPermissionToRole(byte roleId, List<int> permissions)
        {
            foreach (var permission in permissions)
            {
                _context.RolePermissions.Add(new RolePermission()
                {
                    Permission_Id = permission,
                    Role_Id = roleId
                });
                _context.SaveChanges();
            }
        }

        public async Task<List<int>> GetSelectedRolesForEdit(byte roleID)
        {
            return await _context.RolePermissions.Where(r => r.Role_Id == roleID).Select(r => r.Permission_Id).ToListAsync();
        }

        public void EditPermissionRoles(byte roleId, List<int> permissions)
        {
            _context.RolePermissions.Where(p => p.Role_Id == roleId)
                .ToList().ForEach(p => _context.Remove(p));
            AddPermissionToRole(roleId, permissions);
        }

        public bool UserRoles(string username, int permissionId)
        {
            //First we find the userId by username
            var userId = getUserIdByUserName(username);
            //Second we find the roles which are belonged to SelectedUSer
            List<byte> userRoles = _context.UserRoles.Where(u => u.User_Id == userId)
                .Select(u => u.RoleP_Id).ToList();
            if (!userRoles.Any())
                return false;
            //Third we should find the permissions which are related to this list of roles
            List<byte> rolePremissions = _context.RolePermissions.Where(r => r.Permission_Id == permissionId)
                .Select(r => r.Role_Id).ToList();
            //ToDo : always check this quarry this is very important 
            //forth we should find the permissions are contains to roles we find early
            return rolePremissions.Any(r => userRoles.Contains(r));

        }

        public long getUserIdByUserName(string usemname)
        {
            return _context.Users.First(u => u.UserName == usemname).Id;
        }

        #endregion
    }
}
