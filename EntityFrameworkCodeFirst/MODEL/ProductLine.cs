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
        [StringLength(50)]
        public string productLine { get; set; }
        [StringLength(4000)]
        public string textDescription { get; set; }
        public string htmlDescription { get; set; }
        public byte[] image { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
