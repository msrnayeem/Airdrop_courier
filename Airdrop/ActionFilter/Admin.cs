using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// add comment each line

namespace Airdrop.ActionFilter
{
    public class Admin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //store requested route
            var routee = filterContext.HttpContext.Request.Url.AbsolutePath;
            //set route as session
            
            if (HttpContext.Current.Session["Id"] == null)
            {
                HttpContext.Current.Session["Route"] = routee;

                filterContext.Result = new RedirectResult("~/Admin/Login");
                
                //return with tempdata
                filterContext.Controller.TempData["ErrorMessage"] = "You are not authorized to access this page";
                
            }
            base.OnActionExecuting(filterContext);
        }
    }
    
}