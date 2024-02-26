using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.MODEL
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        public int customerNumber { get; set; }
        [StringLength(50)]
        public string customerName { get; set; }
        [StringLength(50)]
        public string contactLastName { get; set; }
        [StringLength(50)]
        public string contactFirstName { get; set; }
        [StringLength(50)]
        public string phone { get; set; }
        [StringLength(50)]
        public string addressLine1 { get; set; }
        [StringLength(50)]
        public string addressLine2 { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string state { get; set; }
        [StringLength(15)]
        public string postalCode { get; set; }
        [StringLength(50)]
        public string country { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal creditLimit { get; set; }
        public ICollection<Orders> orders { get; set; }
    }
}
