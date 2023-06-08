using AutoMapper;
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
    public class ShipmentService
    {
        public static ShipmentDTO AddShipment(ShipmentDTO shipment)
        {
            var data = Convert(shipment);
            return Convert(ShipmentRepo.addShipment(data));            
        }
        public static bool DeleteShipment(int id)
        {
            return ShipmentRepo.DeleteShipment(id);
        }
        public static ShipmentDTO GetShipment(int id)
        {
            var data = ShipmentRepo.GetShipment(id);
            if (data != null)
                return Convert(data);
            return null;
        }
        public static List<ShipmentCustomerDTO> GetShipments()
        {
            var shipments = ShipmentRepo.GetShipments();
            var customers = CustomerRepo.GetCustomers(); // Assuming you have a method to retrieve all customers

            var shipmentCustomerDTOs = shipments.Select(s => new ShipmentCustomerDTO
            {
                Id = s.Id,
                CustomerId = s.CustomerId,
                ReceiverName = s.ReceiverName,
                ReceiverPhone = s.ReceiverPhone,
                ReceiverArea = s.ReceiverArea,
                Payment = s.Payment,
                TrackingId = s.TrackingId,
                CustomerName = customers.FirstOrDefault(c => c.Id == s.CustomerId)?.Name,
                CustomerPhone = customers.FirstOrDefault(c => c.Id == s.CustomerId)?.Phone,     
                CustomerAddress = customers.FirstOrDefault(c => c.Id == s.CustomerId)?.Address
            }).ToList();

            return shipmentCustomerDTOs;
        }
        public static bool UpdateShipment(ShipmentDTO shipment)
        {
            var data = Convert(shipment);
            return ShipmentRepo.UpdateShipment(data);
        }

        //convert 
        public static ShipmentDTO Convert(Shipment shipment)
        {
            return new ShipmentDTO()
            {
                Id = shipment.Id,                
                CustomerId = shipment.CustomerId,
                Payment = shipment.Payment,
                ReceiverName = shipment.ReceiverName,
                ReceiverPhone = shipment.ReceiverPhone,               
                ReceiverArea = shipment.ReceiverArea,
                TrackingId = shipment.TrackingId
            };
        }


        public static Shipment Convert(ShipmentDTO shipment)
        {
            return new Shipment()
            {
                Id = shipment.Id,
                CustomerId = shipment.CustomerId,
                Payment = shipment.Payment,
                ReceiverName = shipment.ReceiverName,
                ReceiverPhone = shipment.ReceiverPhone,
                ReceiverArea = shipment.ReceiverArea,
                TrackingId = shipment.TrackingId
            };
        }
        static List<ShipmentDTO> Convert(List<Shipment> shipment)
        {
            return shipment.Select(x => Convert(x)).ToList();
        }
    }
}
