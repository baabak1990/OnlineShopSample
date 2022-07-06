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
    public class UserRoleConfiquration : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.HasKey(u => new { u.User_Id, u.RoleP_Id });
            builder.HasOne(u => u.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ur => ur.User_Id);
            builder.HasOne(r => r.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ur => ur.RoleP_Id);
        }
    }
}
