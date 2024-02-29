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
    [Table("customer")]
    public class Customer
    {
        [Key]
        public int customerNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string customerName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string contactLastName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string contactFirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string phone { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string addressLine1 { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? addressLine2 { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string city { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? state { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string? postalCode { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string country { get; set; }

        [ForeignKey("employee")]
        public int? salesRepEmployeeNumber { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? creditLimit { get; set; }

        public Employee employee { get; set; }
    }
}
