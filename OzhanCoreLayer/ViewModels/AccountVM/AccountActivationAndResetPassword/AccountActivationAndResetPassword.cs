using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanCoreLayer.ViewModels.Common;

namespace OzhanCoreLayer.ViewModels.AccountVM.AccountActivationAndResetPassword
{
    public class AccountActivationAndResetPasswordvm:GooglereCapchaVm
    {
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string ActiveCode { get; set; }
    }
}
