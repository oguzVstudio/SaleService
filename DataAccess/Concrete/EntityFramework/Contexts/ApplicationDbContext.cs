using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() :base ("ApplicationDbContext")
        {
           
        }

        public DbSet<UserTable> Users { get; set; }
        public DbSet<ProductTable> Products { get; set; }
        public DbSet<SalesTable> Sales { get; set; }
        public DbSet<SaleDetailTable> SaleDetails { get; set; }        
        public DbSet<CustomerTable> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SaleDetailTable>()
                .HasRequired(e => e.Sale)
                .WithMany(d => d.SaleDetails)
                .HasForeignKey(e => e.SaleId);

            modelBuilder.Entity<SaleDetailTable>()
                .HasRequired(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId);
        }
    }
}
