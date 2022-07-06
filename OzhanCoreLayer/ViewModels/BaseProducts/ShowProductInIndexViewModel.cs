using OzhanDomainLayer.Entities.Products.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.ViewModels.BaseProducts
{
    public class ShowProductInIndexViewModel
    {
      
        public long Id { get; set; }

        [Display(Name = "نام کالا")]
        public string Title { get; set; }
        public double PriceBeforeOff { get; set; }
        public double TotalPrice { get; set; }
        public Status IsAvailable { get; set; }
        public string ImageName { get; set; }

    }
}
