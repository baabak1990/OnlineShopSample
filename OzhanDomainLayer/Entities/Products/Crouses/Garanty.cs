using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanDomainLayer.Entities.Products.Crouses
{
    public class Garanty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "")]
        [MaxLength]
        public string Title { get; set; }
        [Display(Name = "مدت زمان")]
        [Required(ErrorMessage = "")]
        [MaxLength]
        public string Duration { get; set; }

        public long BaseProduct_Id { get; set; }
        [Display(Name = "حذف شده")]
        public bool IsDelete { get; set; }
        #region Relations

        public ICollection<ProdcutGaranty> ProdcutGaranties { get; set; }

        #endregion
    }
}
