using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.ViewModels.AccountVM.ResetPassword
{
    public static class ConvertToResetPass
    {
        public static ResetPasswordVm ConvertToPasswordVm(this User user)
        {
            return new ResetPasswordVm()
            {
                ActiveCode = user.ActiveCode,
                Password = user.Password,

            };
        }
    }
}
