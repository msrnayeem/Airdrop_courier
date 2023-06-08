using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models
{
    public class Tracking
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string TrackingId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [ForeignKey("Shipment")]
        public int ShipmnetId { get; set; }
        public virtual Shipment Shipment { get; set; } // Reference navigation property
    }
}
