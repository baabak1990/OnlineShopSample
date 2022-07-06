using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Commons.Base;
using OzhanDomainLayer.Entities.Accounts.BaseClass;

namespace OzhanDomainLayer.Entities.Products.Crouses
{
    public class CourseGroup:BaseEntities<int>,IAudioTable
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Title { get; set; }
        public int? ParentId { get; set; }
        
        #region Relations
        [ForeignKey(nameof(ParentId))]
        public ICollection<CourseGroup> CrouseGroups { get; set; }

        #endregion

        #region General

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        //esme navigation property ro bede na esme fildi ke Id dare
        [InverseProperty("CourseGroup")]
        public ICollection<BaseProduct> Group { get; set; }
        [InverseProperty("subCourseGroup")]
        public ICollection<BaseProduct> SubGroup { get; set; }

        #endregion
    }
}
