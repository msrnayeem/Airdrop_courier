using DA.Context;
using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repos
{
    public class ShipmentRepo
    {
        static AirdropContext db;
        static ShipmentRepo()
        {
            db = new AirdropContext();
        }

        public static Shipment addShipment(Shipment shipment)
        {
            db.Shipments.Add(shipment);
            db.SaveChanges();
            return shipment;
        }

        public static bool DeleteShipment(int id)
        {
            var shipment = db.Shipments.Find(id);
            db.Shipments.Remove(shipment);
            return db.SaveChanges() > 0;
        }

        public static Shipment GetShipment(int id)
        {
            return db.Shipments.Find(id);
        }

        public static List<Shipment> GetShipments()
        {
            return db.Shipments.ToList();
            
        }

        public static bool UpdateShipment(Shipment shipment)
        {
            var oldShipment = db.Shipments.Find(shipment.Id);
            
            oldShipment.CustomerId = shipment.CustomerId;
            oldShipment.Payment = shipment.Payment;
            oldShipment.ReceiverName = shipment.ReceiverName;
            oldShipment.ReceiverArea = shipment.ReceiverArea;
            oldShipment.ReceiverPhone = shipment.ReceiverPhone;
            oldShipment.TrackingId  = shipment.TrackingId;
            return db.SaveChanges() > 0;
        }


    }
}
