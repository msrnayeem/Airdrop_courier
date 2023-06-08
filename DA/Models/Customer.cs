using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        // start with 01 and total 11 digit number

        [Required]
        [RegularExpression(@"^01\d{9}$")]
        public string Phone { get; set; }

        public virtual ICollection<Shipment> Shipments { get; set; } // Navigation property
    }
}
