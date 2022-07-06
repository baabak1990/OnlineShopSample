using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.ViewModels.PermissionsViewModels
{
    public static class ConvertorsToVm
    {
        public static RoleEditVM RoleModelToVm(this Role role)
        {
            return new RoleEditVM()
            {
                Id = role.Id,
                Title = role.Title
            };
        }

        public static IQueryable<RoleEditVM> RoleModelToVm(this IQueryable<Role> roles)
        {
            return roles.Select(r => r.RoleModelToVm());
        }
    }
}
