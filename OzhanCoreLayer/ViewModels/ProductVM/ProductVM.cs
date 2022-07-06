using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanCoreLayer.Services.GeneralServices;
using OzhanDomainLayer.Entities.Products.Common;
using OzhanDomainLayer.Entities.Products.Crouses;

namespace OzhanCoreLayer.ViewModels.ProductVM
{
    public class ProductGroupeCreateOrEdit : ICreateOrEditVM<int>
    {
        public int ID { get; set; }
        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(150)]
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class ProductGroupeIndex : IIndexVm<int>
    {
        public string Title { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ParentId { get; set; }
        public bool ISDelete { get; set; }
        public IEnumerable<CourseGroup> ListCourse { get; set; }
    }
}
