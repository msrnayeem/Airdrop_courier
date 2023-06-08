using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TrackingDTO
    {
        public int Id { get; set; }

        public string TrackingId { get; set; }

        public string Status { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int ShipmnetId { get; set; }
        
    }
}
