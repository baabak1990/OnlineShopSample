using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.ViewModels.AccountVM.UserPanelViewModels.UserPanelChangePassword
{
    public class ChangeUserPanelPasswordVm
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

        [Display(Name = "کلمه عبور فعلی")]
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
    }
}
