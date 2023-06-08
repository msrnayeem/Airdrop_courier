using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Airdrop.Controllers
{
    public class ShipmentController : Controller
    {
        // GET: Shipment
        public ActionResult Shipments()
        {
            var data = ShipmentService.GetShipments();
            return View(data);
        }

        public ActionResult AddShipment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShipment(FormCollection form)
        {
            
            var customer = new CustomerDTO
            {
                Name = form["senderName"],
                Address = form["senderAddress"],
                Phone = form["senderPhone"]
            };
            var customerId = CustomerService.AddCustomer(customer);

            //genearte tracking number using customer id and time format airdrop_1_2021-01-01_12-00-00
            var trackingNumber = $"airdrop_{customerId}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";

            var shipment = new ShipmentDTO
            {
                CustomerId = customerId,
                ReceiverName = form["receiverName"],
                ReceiverArea = form["receiverAddress"],
                ReceiverPhone = form["receiverPhone"],
                Payment = form["payment"],
                TrackingId = trackingNumber
            };  
            var shipmentInfo = ShipmentService.AddShipment(shipment);

            //add tracking  info
            var tracking = new TrackingDTO
            {
                TrackingId = trackingNumber,
                Status = "Pending",
                BookingDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(3),
                ShipmnetId = shipmentInfo.Id
            };
            //add tracking info
            var trackingInfo = TrackingService.AddTracking(tracking);
            
            var successMessage = $"Tracking number: {trackingNumber} approx delivery date: {trackingInfo.DeliveryDate}";
            TempData["msg"] = successMessage; // Set success message including the tracking number using TempData

            return RedirectToAction("Shipments"); // Redirect to the Shipments action
        }

        //Tracking
        public ActionResult Tracking()
        {
            // get data from tracking service
            var data = TrackingService.GetTrackings();
            return View(data);
           
        }

        //Tracking update by tracking id and delivery date
        
        public ActionResult UpdateTracking(int trackId, string deliveryDate, string status)
        {
            // Convert the string delivery date to DateTime
            var deliveryDatee = Convert.ToDateTime(deliveryDate);
            try
            {
                var data = TrackingService.GetTracking(trackId);
                var ob = new TrackingDTO
                {
                    Id = data.Id,
                    TrackingId = data.TrackingId,
                    Status = status,
                    BookingDate = data.BookingDate,
                    DeliveryDate = deliveryDatee,
                    ShipmnetId = data.ShipmnetId
                };
                var updated = TrackingService.UpdateTracking(ob); // Pass 'ob' instead of 'data'

                // Assuming the update was successful, return a success message
                return Json(new { success = true, message = "Tracking updated successfully" });
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the update process
                // You can log the exception or perform any other necessary actions

                // Return an error message
                return Json(new { success = false, message = "Failed to update tracking: " + ex.Message });
            }
        }

        public ActionResult Trackingg(string tno)
        {
            var data = TrackingService.GetTrackingByTID(tno);
            if (data == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            // Format the date values
            var bookingDate = data.BookingDate.ToString("dd/MM/yyyy");
            var deliveryDate = data.DeliveryDate.ToString("dd/MM/yyyy");

            // Create an anonymous object with the formatted values
            var formattedData = new
            {
                data.TrackingId,
                data.Status,
                BookingDate = bookingDate,
                DeliveryDate = deliveryDate,
                // Include other properties as needed
            };

            // Return the JSON response with the formatted data
            return Json(formattedData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetTrackingDetails(string tno)
        {
            var data = TrackingService.GetTrackingByTID(tno);
            
            var details = ShipmentService.GetShipment(data.ShipmnetId);

            var customer = CustomerService.GetCustomer(details.CustomerId);

            // Format the date values
            ViewBag.Customername = customer.Name;
            ViewBag.CustomerAddress = customer.Address;
            ViewBag.CustomerPhone = customer.Phone;
            ViewBag.TrackingId = data.TrackingId;
            ViewBag.bookingDate = data.BookingDate.ToString("dd/MM/yyyy");
            ViewBag.deliveryDate = data.DeliveryDate.ToString("dd/MM/yyyy");
            ViewBag.TrackingId = data.TrackingId;
            ViewBag.ReceiverName = details.ReceiverName;
            ViewBag.ReceiverPhone = details.ReceiverPhone;
            ViewBag.ReceiverArea = details.ReceiverArea;
            ViewBag.Payment = details.Payment;
            ViewBag.Status = data.Status;
            
            
            return View();
        }

    }
}