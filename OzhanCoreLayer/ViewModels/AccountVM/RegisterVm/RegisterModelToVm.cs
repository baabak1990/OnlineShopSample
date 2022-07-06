using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.ViewModels.AccountVM.RegisterVm
{
    public static class RegisterModelToVm
    {
        public static registerUserForCreateViewModel registerModelToVm(this User user)
        {
            return new registerUserForCreateViewModel()
            {
                Email = user.Email,
                CreateDate = user.CreateDate,
                ModifyDate = user.ModifyDate,
                Password = user.Password,
                UserName = user.UserName
            };
        }

        public static IQueryable<registerUserForCreateViewModel> registerModelToVm(this IQueryable<User> users)
        {
            return users.Select(u => u.registerModelToVm());
        }
    }
}
