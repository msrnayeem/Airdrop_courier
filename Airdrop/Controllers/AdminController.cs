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
                TempData["ErrorMessage"] = "Invalid Email or Password";
                // redirect to home/login
                return RedirectToAction("Login", "Home");
            }
        }        
    }
}