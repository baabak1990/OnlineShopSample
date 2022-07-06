using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzhanDomainLayer.Entities.Products.Orders;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanDataLayer.FluentsConfiquration
{
    public class OrderConfiqurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.Property(x => x.CreatDate).IsRequired();
            builder.Property(x => x.OrderSum).IsRequired();
            builder.HasOne<User>(b => b.User)
                .WithMany(b => b.orders)
                .HasForeignKey(b => b.UserId);

        }
    }
}
