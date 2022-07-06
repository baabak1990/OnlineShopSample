using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzhanDomainLayer.Entities.Products.Crouses;
using OzhanDomainLayer.Entities.Products.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanDataLayer.FluentsConfiquration
{
    public class OrderDetaileConfiguration : IEntityTypeConfiguration<OrderDetailes>
    {
        public void Configure(EntityTypeBuilder<OrderDetailes> builder)
        {
          
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Count).IsRequired();
            builder.HasQueryFilter(x=>!x.IsDeleted);
            builder.HasOne<Order>(x => x.Order)
                .WithMany(x => x.OrderDetailes)
                .HasForeignKey(x => x.OrderId);
            builder.HasOne<BaseProduct>(x => x.Product)
                .WithMany(x => x.OrderDetailes)
                .HasForeignKey(x => x.BaseProductId);

        }
    }
}
