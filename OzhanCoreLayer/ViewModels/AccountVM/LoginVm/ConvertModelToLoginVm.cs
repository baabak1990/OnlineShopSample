using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.ViewModels.AccountVM.LoginVm
{
   public static class ConvertModelToLoginVm
    {
        public static LoginVm convetModelToLogin(this User user)
        {
            return new LoginVm()
            {
                Email = user.Email,
                Password = user.Password,
                Id = user.Id,
                UserName = user.UserName

            };
        }

        public static IQueryable<LoginVm> convetModelToLogin(this IQueryable<User> users)
        {
            return users.Select(u => u.convetModelToLogin());
        }
    }
}
