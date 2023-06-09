using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airdrop.ActionFilter
{
    public class Admin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Id"] == null)
            {
                filterContext.Result = new RedirectResult("~/Admin/Login");
                
                //return with tempdata
                filterContext.Controller.TempData["ErrorMessage"] = "You are not authorized to access this page";
                
            }
            base.OnActionExecuting(filterContext);
        }
    }
    
}