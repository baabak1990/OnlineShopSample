using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Commons.Base;
using OzhanDomainLayer.Entities.Accounts.BaseClass;

namespace OzhanDomainLayer.Entities.Accounts.User
{
    public class UserDetailes : BaseEntities<long>, IAudioTable
    {
        #region Generals

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        #endregion

        #region Properties
        [Display(Name = "شماره تماس")]
        [MaxLength(100)]
        [RegularExpression("(0 |\\+98)?([]|-|[()]){0,2}9[1|2|3|4] ([]|-|[()]){0,2}(?:[0-9] ([]|-|[()]){0,2}){8}")]
        public string PhoneNumber { get; set; }
        [Display(Name = "آدرس پستی")]
        [MaxLength(100)]
        public string Address { get; set; }
        [Display(Name = "استان")]
        [MaxLength(100)]
        public string State { get; set; }
        [Display(Name = "شهر")]
        [MaxLength(100)]
        public string City { get; set; }
        [Display(Name = "روستا یا بخش")]
        [MaxLength(100)]
        public string Urban { get; set; }
        [Display(Name = "جزییات تکمیلی")]
        [MaxLength(100)]
        public string Details { get; set; }

        #endregion

        #region Relations

        public User User { get; set; }
     
        #endregion
    }
}
