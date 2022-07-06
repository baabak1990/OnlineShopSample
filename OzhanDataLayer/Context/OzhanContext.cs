using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OzhanDataLayer.FluentsConfiquration;
using OzhanDomainLayer.Entities.Accounts.User;
using OzhanDomainLayer.Entities.Products.Crouses;
using OzhanDomainLayer.Entities.Products.Orders;

namespace OzhanDataLayer.Context
{
    public class OzhanContext : DbContext
    {
        public OzhanContext(DbContextOptions<OzhanContext> options) : base(options)
        {

        }

        #region Dbset

        public DbSet<User> Users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Garanty> Garanties { get; set; }
        public DbSet<BaseProduct> baseProducts { get; set; }
        public DbSet<ProdcutGaranty> ProdcutGaranties { get; set; }
        public DbSet<CourseGroup> CourseGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetailes> OrderDetailes { get; set; }


        #endregion


        #region ModelBuilder

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseGroup>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Garanty>().HasQueryFilter(c => !c.IsDelete);
            modelBuilder.ApplyConfiguration(new UserConfiq());
            modelBuilder.ApplyConfiguration(new UserDetailsComfiq());
            modelBuilder.ApplyConfiguration(new UserRoleConfiquration());
            modelBuilder.ApplyConfiguration(new OrderConfiqurations());
            modelBuilder.ApplyConfiguration(new OrderDetaileConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
