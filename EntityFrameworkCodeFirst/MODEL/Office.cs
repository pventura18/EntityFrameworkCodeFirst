using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.MODEL
{
    [Table("offices")]
    public class Office
    {
        [Key]
        [StringLength(10)]
        public string officeCode { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string phone { get; set; }
        [StringLength(50)]
        public string addressLine1 { get; set; }
        [StringLength(50)]
        public string addressLine2 { get; set; }
        [StringLength(50)]
        public string state { get; set; }
        [StringLength(50)]
        public string country { get; set; }
        [StringLength(15)]
        public string postalCode { get; set; }
        [StringLength(10)]
        public string territory { get; set; }
        [StringLength(10)]
        public ICollection<Employee> employees { get; set; }

    }
}
