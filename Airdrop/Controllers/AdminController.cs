using Airdrop.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airdrop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
           
            // Retrieve TempData value set in the Admin action filter
            string errorMessage = TempData["ErrorMessage"] as string;

            // Check if TempData value exists and handle it accordingly
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewBag.ErrorMessage = errorMessage;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            //login service
            var data = AdminService.Login(login.Email, login.Password);
            if (data != 0)
            {
                //set session
                Session["Id"] = data;
                //check if session has route
                if (Session["Route"] != null)
                {
                    //get route from session
                    var route = Session["Route"].ToString();
                    //remove session
                    Session["Route"] = null;
                    //redirect to route
                    return Redirect(route);
                }
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid Email or Password";
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session["Id"] = null;
            Session["Route"] = null;
            return Json(new { success = true });
        }

        public ActionResult AdminProfile()
        {
            //get session
            var id = Session["Id"];
            if(id != null)
            {
                //get data from db
                var data = AdminService.GetAdmin(Convert.ToInt32(id));
                return View(data);
            }
            else
            {
                TempData["ErrorMessage"] = "Login first";
                // redirect to home/login
                return RedirectToAction("Login", "Home");
            }
        }        
    }
}