using EntityFrameworkCodeFirst.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.MODEL
{
    [Table("orderdetails")]
    public class OrderDetail
    {
        [ForeignKey("order")]
        public int orderNumber { get; set; }
        [ForeignKey("product")]
        [Column(TypeName = "varchar(15)")]
        public string productCode { get; set; }
        public int quantityOrdered { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double priceEach { get; set; }
        [Column(TypeName = "smallint(6)")]
        public short orderLineNumber { get; set; }

        public Order order { get; set; }
        public Product product { get; set; }
    }
}
