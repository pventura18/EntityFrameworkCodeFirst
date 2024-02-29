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
    [Table("employees")]
    public class Employee
    {
        [Key]
        public int employeeNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string lastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string firstName { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string extension { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string email { get; set; }
        [ForeignKey("offices")]
        [Column(TypeName = "varchar(10)")]
        public string officeCode { get; set; }
        [ForeignKey("ReportsToRef")]
        public int? reportsTo { get; set; }
        public Employee ReportsToRef { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string jobTitle { get; set; }

        public Office offices { get; set; }
        
    }
}
