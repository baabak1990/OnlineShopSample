using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.ViewModels.AccountVM.UserPanelViewModels
{
    public class UserPanelInformationForShow
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }
        [Display(Name = "نام ")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [MaxLength(100)]
        public string Family { get; set; }

        [Display(Name = "آدرس ایمیل")]
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string  AvatarName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string FullName
        {
            get
            {

                return Name + Family;

            }
        }
        [Display(Name = "کیف پول")]
        public double Wallet { get; set; }
    }
}
