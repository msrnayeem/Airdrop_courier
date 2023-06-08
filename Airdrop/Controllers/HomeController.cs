using Airdrop.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Airdrop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            //login service
            var data = AdminService.Login(login.Email, login.Password);
            if(data != 0)
            {
                //set session
                Session["Id"] = data;

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
            return Json(new { success = true });
        }
    }
}