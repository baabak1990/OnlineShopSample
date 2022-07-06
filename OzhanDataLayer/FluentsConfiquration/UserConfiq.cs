using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzhanDomainLayer.Entities.Accounts.User;

namespace OzhanDataLayer.FluentsConfiquration
{
    public class UserConfiq : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasQueryFilter(u => !u.IsDeleted);

            builder.HasOne<UserDetailes>(b => b.UserDetails)
                .WithOne(b => b.User)
                .HasForeignKey<User>(b => b.UserDetai_Id);

            builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
            var date = new DateTime(2022, 03, 11);
            builder.HasData(new User()
            {
                ActiveCode = "1234",
                CreateDate = date,
                Email = " baabakaghaei@gmail.com",
                Id = 1,
                ImageName = "default",
                IsDeleted = false,
                Family = "Aghaei",
                Name = "baabak",
                Password = "1234",
                UserName = "Admin",
                UserDetai_Id = 1

            });
        }
    }
}
