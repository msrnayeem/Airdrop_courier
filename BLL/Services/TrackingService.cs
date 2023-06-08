using BLL.DTO;
using DA.Models;
using DA.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TrackingService
    {
        public static TrackingDTO AddTracking(TrackingDTO tracking)
        {
            var data = Convert(tracking);
            return Convert(TrackingRepo.AddTracking(data));
        }
        public static bool DeleteTracking(int id)
        {
            return TrackingRepo.DeleteTracking(id);
        }
        public static TrackingDTO GetTracking(int trackingID)
        {
            var data = TrackingRepo.GetTracking(trackingID);
            if (data != null)
                return Convert(data);
            return null;
        }
        public static List<TrackingDTO> GetTrackings()
        {
            var data = TrackingRepo.GetTrackings();
            if (data != null)
                return Convert(data);
            return null;
        }
        public static bool UpdateTracking(TrackingDTO tracking)
        {
            var data = Convert(tracking);
            return TrackingRepo.UpdateTracking(data);
        }

        public static TrackingDTO GetTrackingByTID(string trackingId)
        {
            var data = TrackingRepo.GetTrackingByTID(trackingId);
            if (data != null)
                return Convert(data);
            return null;
        }

        //convert 
        public static TrackingDTO Convert(Tracking tracking)
        {
            return new TrackingDTO()
            {
                Id = tracking.Id,

                TrackingId = tracking.TrackingId,

                Status = tracking.Status,

                BookingDate = tracking.BookingDate,

                DeliveryDate = tracking.DeliveryDate,

                ShipmnetId = tracking.ShipmnetId,
            };
        }  
        public static Tracking Convert(TrackingDTO tracking)
        {
            return new Tracking()
            {
                Id = tracking.Id,

                TrackingId = tracking.TrackingId,

                Status = tracking.Status,

                BookingDate = tracking.BookingDate,

                DeliveryDate = tracking.DeliveryDate,

                ShipmnetId = tracking.ShipmnetId,
            };
        }

        public static List<TrackingDTO> Convert(List<Tracking> tracking)
        {
            return tracking.Select(x => Convert(x)).ToList();
        }


    }

}    