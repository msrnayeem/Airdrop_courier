using DA.Context;
using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repos
{
    public class TrackingRepo
    {
        static AirdropContext db;
        static TrackingRepo()
        {
            db = new AirdropContext();
        }

        public static Tracking AddTracking(Tracking tracking)
        {
            //add and return tracking object
            db.Trackings.Add(tracking);
            db.SaveChanges();
            return tracking;
        }
        public static bool DeleteTracking(int id)
        {
            var tracking = db.Trackings.Find(id);
            db.Trackings.Remove(tracking);
            return db.SaveChanges() > 0;
        }

        public static Tracking GetTracking(int id)
        {
            return db.Trackings.Find(id);
        }

        public static List<Tracking> GetTrackings()
        {
            return db.Trackings.ToList();
        }

        public static bool UpdateTracking(Tracking tracking)
        {
            var oldTracking = db.Trackings.Find(tracking.Id);
            oldTracking.Status = tracking.Status;
            oldTracking.BookingDate = tracking.BookingDate;
            oldTracking.DeliveryDate = tracking.DeliveryDate;
            oldTracking.ShipmnetId = tracking.ShipmnetId;
            return db.SaveChanges() > 0;
        }
        public static Tracking GetTrackingByTID(string trackingId)
        {
            return db.Trackings.Where(t => t.TrackingId == trackingId).FirstOrDefault();
        }
    }
}
