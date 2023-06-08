﻿using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airdrop.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Customers()
        {
            var data = CustomerService.GetCustomers();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            CustomerService.DeleteCustomer(id);
            //return with success message
            TempData["msg"] = "Customer deleted successfully";

            return RedirectToAction("Customers");
        }
    }
}