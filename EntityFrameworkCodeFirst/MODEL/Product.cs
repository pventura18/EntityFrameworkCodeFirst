using EntityFrameworkCodeFirst.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.MODEL
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column(TypeName = "varchar(15)")]
        public string productCode { get; set; }
        [Column(TypeName = "varchar(70)")]
        public string productName { get; set; }
        [ForeignKey("ProductLines")]
        [Column(TypeName = "varchar(50)")]
        public string productLine { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string productScale { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string productVendor { get; set; }
        [Column(TypeName = "text")]
        public string productDescription { get; set; }
        [Column(TypeName = "smallint(6)")]
        public short quantityInStock { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double BuyPrice { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double MSRP { get; set; }

        public ProductLine ProductLines { get; set; }
    }
}
