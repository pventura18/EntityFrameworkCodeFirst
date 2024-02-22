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
        [StringLength(15)]
        public string productCode { get; set; }
        [StringLength(70)]
        public string productName { get; set; }
        [StringLength(10)]
        public string productScale { get; set; }
        [StringLength(50)]
        public string productVendor { get; set; }
        public string productDescription { get; set; }
        [Column(TypeName = "smallint")]
        public int quantityInStock { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal buyPrice { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal MSRP { get; set; }
    }
}
