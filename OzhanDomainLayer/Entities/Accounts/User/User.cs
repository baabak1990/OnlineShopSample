using OzhanDomainLayer.Commons.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Entities.Accounts.BaseClass;
using OzhanDomainLayer.Entities.Products.Orders;

namespace OzhanDomainLayer.Entities.Accounts.User
{
    public class User : BaseEntities<long>, IAudioTable
    {
        #region Generals

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public string FullName
        {
            get
            {
                return Name + Family;
            }
        }

        #endregion

        #region Properties
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

        [Display(Name = "کلمه عبور")]
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "کد فعالسازی")]
        [MaxLength(100)]
        public string ActiveCode { get; set; }
        [Display(Name = "آیا فعال هست ؟")]
        public bool IsActive { get; set; }
        [Display(Name = "تصویر")]
        [MaxLength(100)]
        public string ImageName { get; set; }




        #endregion

        #region Relations

        public long? UserDetai_Id { get; set; }
        public UserDetailes UserDetails { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<Order> orders { get; set; }

        #endregion
    }
}
