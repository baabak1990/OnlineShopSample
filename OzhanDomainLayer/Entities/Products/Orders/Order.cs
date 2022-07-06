using OzhanDomainLayer.Entities.Accounts.BaseClass;
using OzhanDomainLayer.Entities.Accounts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanDomainLayer.Entities.Products.Orders
{
    public class Order : BaseEntities<long>
    {
        public long UserId { get; set; }
        public DateTime CreatDate { get; set; }
        public double OrderSum { get; set; }
        public bool IsFinaly { get; set; }

        #region Relations
        public User User { get; set; }
        public ICollection<OrderDetailes> OrderDetailes { get; set; }
        #endregion
    }
}
