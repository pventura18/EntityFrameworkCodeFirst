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
    }
}
