using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.MODEL
{
    [Table("employees")]
    public class Employee
    {
        [Key]

        public int employeeNumber { get; set; }
        [StringLength(50)]
        public string lastName { get; set; }
        [StringLength(50)]
        public string firstName { get; set; }
        [StringLength(10)]
        public string extension { get; set; }
        [StringLength(100)]
        public string email { get; set; }

        //public int reportsTo { get; set; }
        [StringLength(50)]
        public string jobTitle { get; set; }
    }
}
