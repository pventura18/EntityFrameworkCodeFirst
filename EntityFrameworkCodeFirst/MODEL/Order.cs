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
    [Table("orders")]
    public class Order
    {
        [Key]
        public int orderNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime orderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime requiredDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? shippedDate { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string status { get; set; }
        [Column(TypeName = "text")]
        public string? comments { get; set; }
        [ForeignKey("customer")]
        public int customerNumber { get; set; }

        public Customer customer { get; set; }
    }
}
