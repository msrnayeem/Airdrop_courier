using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models
{
    public class Shipment
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } // Reference navigation property

        [Required]
        public string Payment { get; set; }

        [Required]
        public string ReceiverName { get; set; }

        [Required]
        [RegularExpression(@"^01\d{9}$")]
        public string ReceiverPhone { get; set; }

        [Required]
        public string ReceiverArea { get; set; }        

        [Required]
        public string TrackingId { get; set; }
    }
}
