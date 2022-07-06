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
    public class UserDetailsComfiq : IEntityTypeConfiguration<UserDetailes>
    {
        public void Configure(EntityTypeBuilder<UserDetailes> builder)
        {
            
            builder.HasQueryFilter(b => !b.IsDeleted);
            var date = new DateTime(2022, 03, 11, 12, 23, 30);
            builder.HasData(new UserDetailes()
            {
                Address = "teh",
                CreateDate = date,
                Id = 1
            });
        }
    }
}
