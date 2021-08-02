using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SohaService.DataLayer.Entities.Company;
using SohaService.DataLayer.Entities.Customer;
using SohaService.DataLayer.Entities.Expert;
using SohaService.DataLayer.Entities.Orders;
using SohaService.DataLayer.Entities.Permission;
using SohaService.DataLayer.Entities.Unit;
using SohaService.DataLayer.Entities.User;

namespace SohaService.DataLayer.Context
{
    public class SohaServiceContext : DbContext
    {
        public SohaServiceContext(DbContextOptions<SohaServiceContext> options) : base(options)
        {

        }

        #region User

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Permission

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        #endregion

        #region Company

        public DbSet<Company> Companies { get; set; }

        #endregion

        #region Customer

        public DbSet<Customer> Customers { get; set; }

        #endregion

        #region Expert

        public DbSet<Expert> Experts { get; set; }

        #endregion

        #region Order

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLevel> OrderLevels { get; set; }
        public DbSet<SendToCompany> SendToCompanies { get; set; }

        #endregion

        #region Unit

        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitStatus> UnitStatus { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Company>().HasQueryFilter(s => !s.IsDelete);
            modelBuilder.Entity<Customer>().HasQueryFilter(s => !s.IsDelete);
            modelBuilder.Entity<Expert>().HasQueryFilter(s => !s.IsDelete);
            modelBuilder.Entity<Order>().HasQueryFilter(s => !s.IsDelete);
            modelBuilder.Entity<SendToCompany>().HasQueryFilter(s => !s.IsDelete);
            modelBuilder.Entity<Unit>().HasQueryFilter(s => !s.IsDelete);
            modelBuilder.Entity<UnitStatus>().HasQueryFilter(s => !s.IsDelete);


            base.OnModelCreating(modelBuilder);
        }
    }
}
