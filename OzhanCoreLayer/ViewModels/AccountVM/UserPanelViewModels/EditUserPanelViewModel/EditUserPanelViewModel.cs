using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzhanCoreLayer.ViewModels.AccountVM.UserPanelViewModels.EditUserPanelViewModel
{
    public class EditUserPanelViewModel
    {
        [Display(Name = "نام کاربری")]
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

        [Display(Name = "آخرین ویرایش")]
        public DateTime? ModifyDate { get; set; }

        [Display(Name = "آواتار")]
        public string ImageName { get; set; }
        public IFormFile AvatarName { get; set; }
    }
}
