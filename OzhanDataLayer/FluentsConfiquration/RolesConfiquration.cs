using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanDataLayer.FluentsConfiquration
{
    public class RolesConfiquration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Title).IsRequired();
            builder.HasQueryFilter(r => !r.IsDeleted);
        }
    }
}
