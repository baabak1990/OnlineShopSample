using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanCoreLayer.ViewModels.Common;

namespace OzhanCoreLayer.ViewModels.AccountVM.ForgetPassword
{
    public class ForgotPasswordViewModel:GooglereCapchaVm
    {
        [Display(Name = "آدرس ایمیل")]
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string UserName { get; set; }
        public string ActiveCode { get; set; }

        
    }
}
