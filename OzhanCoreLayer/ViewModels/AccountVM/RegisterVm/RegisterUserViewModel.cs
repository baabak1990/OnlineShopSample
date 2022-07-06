using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanCoreLayer.Services.GeneralServices;
using OzhanCoreLayer.ViewModels.Common;

namespace OzhanCoreLayer.ViewModels.AccountVM.RegisterVm
{
    public class registerUserForCreateViewModel : ICreateOrEditVM<long>
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "آدرس ایمیل")]
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

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

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Capcha { get; set; }

        }

    public class registerUserForEditViewModel : IIndexVm<long>
    {

    }

}
