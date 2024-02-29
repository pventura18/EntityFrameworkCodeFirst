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
    [Table("payments")]
    public class Payment
    {
        [Key]
        [ForeignKey("customer")]
        public int customerNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string checkNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime paymentDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double amount { get; set; }

        public Customer customer { get; set; }
    }
}
