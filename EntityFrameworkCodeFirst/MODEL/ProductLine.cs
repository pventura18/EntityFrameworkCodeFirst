using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.MODEL
{
    [Table("productlines")]
    public class ProductLine
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string productLine { get; set; }
        [Column(TypeName = "varchar(4000)")]
        public string? textDescription { get; set; }
        [Column(TypeName = "mediumtext")]
        public string? htmlDescription { get; set; }
        [Column(TypeName = "mediumblob")]
        public string? image { get; set; }
    }
}
