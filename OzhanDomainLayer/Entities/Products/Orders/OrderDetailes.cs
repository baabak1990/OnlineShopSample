using OzhanDomainLayer.Entities.Accounts.BaseClass;
using OzhanDomainLayer.Entities.Products.Crouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanDomainLayer.Entities.Products.Orders
{
    public class OrderDetailes: BaseEntities<long>
    {
        public long OrderId { get; set; }
        public long BaseProductId { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }


        #region Relations
        public Order Order { get; set; }
        public BaseProduct Product { get; set; }

        #endregion
    }
}
