using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ShipmentDTO
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Payment { get; set; }   
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverArea { get; set; }
        public string TrackingId { get; set; }
    }
}
