using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.MODEL
{
    [Table("specialpricelist")]
    public class SpecialPriceList
    {
        [ForeignKey("Customer")]
        public int customerId { get; set; }

        [ForeignKey("Product")]
        [Column(TypeName = "varchar(15)")]
        public string productCode { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
