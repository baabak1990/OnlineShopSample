using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanDomainLayer.Entities.Products.Common
{
    public enum Color
    {

        قرمز,
        آبی,
        زرد,
        سبز,
        سیاه,
        [Display(Name ="قهوه ای")]
        قهوه_ای
            , نارنجی
    }
}
