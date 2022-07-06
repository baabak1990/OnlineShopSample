using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.ViewModels.AccountVM.AccountActivationAndResetPassword
{
    public static class convertorToVm
    {
        public static AccountActivationAndResetPasswordvm convertToActive(this User user)
        {
            return new AccountActivationAndResetPasswordvm()
            {
                ActiveCode = user.ActiveCode,
                Email = user.Email,
                UserName = user.UserName
            };
        }
    }
}
