using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OzhanCoreLayer.Services.GeneralServices;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanCoreLayer.ViewModels.AdminVm
{
    public class AdminIndexViewModel : IIndexVm<long>
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Username { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Display(Name = "فعال/غیر فعال")]
        public bool IsActive { get; set; }
        [Display(Name = "تاریخ ثبت نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public DateTime SignUpDate { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<User> ListOfUsers { get; set; }
    }

    public class AdminCreateOrEditViewModel : ICreateOrEditVM<long>
    {
        public long? Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Username { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Display(Name = "فعال/غیر فعال")]
        public bool IsActive { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Password { get; set; }
        public IFormFile UserAvatar { get; set; }
        [Display(Name = "تصویر کاربر")]
        public string UserImage { get; set; }
        [Display(Name = "آخرین ویرایش")]
        public DateTime? ModifyDate { get; set; }

        public List<byte> SelectedRoles { get; set; }
    }

    public class EdidUserFromAdmin
    {
        public long Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Username { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Display(Name = "فعال/غیر فعال")]
        public bool IsActive { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Password { get; set; }
        public IFormFile UserAvatar { get; set; }
        [Display(Name = "تصویر کاربر")]
        public string UserImage { get; set; }
        [Display(Name = "آخرین ویرایش")]
        public DateTime? ModifyDate { get; set; }
        public DateTime CreateDate { get; set; }

        public List<byte> SelectedRoles { get; set; }
    }
}
