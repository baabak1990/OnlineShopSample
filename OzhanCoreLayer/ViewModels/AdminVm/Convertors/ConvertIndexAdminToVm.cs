using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.ViewModels.AdminVm.Convertors
{
    public static class ConvertIndexAdminToVm
    {
        public static AdminIndexViewModel ConvertModelToAdminIndexVm(this User user)
        {
            return new AdminIndexViewModel()
            {
                Email = user.Email,
                Id = user.Id,
                IsActive = user.IsActive,
                SignUpDate = user.CreateDate,
                Username = user.UserName
            };
        }

        public static IQueryable<AdminIndexViewModel> ConvertModelToAdminIndexVm(this IQueryable<User> users)
        {
            return users.Select(u => u.ConvertModelToAdminIndexVm());
        }
        public static IEnumerable<AdminIndexViewModel> ConvertModelToAdminIndexVm(this IEnumerable<User> users)
        {
            return users.Select(u => u.ConvertModelToAdminIndexVm());
        }
    }
}
