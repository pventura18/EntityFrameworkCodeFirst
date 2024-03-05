using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.MODEL
{
    public class BusinessDBContext : DbContext
    {

        public BusinessDBContext() { }

        public BusinessDBContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=BUSINESS;Uid=root;Pwd=\"\"");
            }
        }

        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SpecialPriceList> SpecialPriceList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasKey(o => new { o.customerNumber, o.checkNumber });
            modelBuilder.Entity<OrderDetail>().HasKey(o => new { o.orderNumber, o.productCode });
            modelBuilder.Entity<SpecialPriceList>().HasKey(o => new { o.productCode, o.customerId });
        }
    }
}
