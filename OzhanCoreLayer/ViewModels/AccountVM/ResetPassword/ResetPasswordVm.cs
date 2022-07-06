using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using OzhanCoreLayer.ViewModels.Common;

namespace OzhanCoreLayer.ViewModels.AccountVM.ResetPassword
{
   public class ResetPasswordVm:GooglereCapchaVm
    {

        [Display(Name = "کلمه عبور")]
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "کلمات عبور یکسان نمی باشند!")]
        public string RePassword { get; set; }
        public string ActiveCode { get; set; }
    }
}
