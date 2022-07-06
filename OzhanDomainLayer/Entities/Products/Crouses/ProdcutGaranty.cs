using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanDomainLayer.Entities.Products.Crouses
{
    public class ProdcutGaranty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PGA_Id { get; set; }
        public byte Garanty_Id { get; set; }
        public long BaseProduct_Id { get; set; }



        [ForeignKey("BaseProduct_Id")]
        public BaseProduct Product { get; set; }

        [ForeignKey("Garanty_Id")]
        public Garanty Garanty { get; set; }
    }
}
