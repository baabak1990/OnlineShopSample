using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.ViewModels.AccountVM.ForgetPassword
{
   public static class ModelConvertToPassVm
    {
        public static ForgotPasswordViewModel convertToPassVm(this User user)
        {
            return new ForgotPasswordViewModel()
            {
                Email = user.Email,
                ActiveCode = user.ActiveCode,
                UserName = user.UserName
            };
        }
    }
}
