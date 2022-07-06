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
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(b => b.RP_Id);
            builder.HasOne(b => b.Permission)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(b => b.Permission_Id);
            builder.HasOne(b => b.Role)
                .WithMany(b => b.RolePermissions)
                .HasForeignKey(b => b.Role_Id);
        }
    }
}
