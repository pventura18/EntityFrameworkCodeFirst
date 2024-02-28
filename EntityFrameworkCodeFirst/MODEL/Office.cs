using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.MODEL
{
    [Table("offices")]
    public class Office
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        public string officeCode { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string city { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string phone { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string addressLine1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? addressLine2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? state { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string country { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string postalCode { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string territory { get; set; }
    }
}
