using SaharaChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SaharaChat.Controllers
{
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Get our database context
            var db = new SaharaContext();

            //Fetch first row (should be one or none) which have our Session.SessionID in SessionID column
            var result = db.Users.Where(u => u.SessionID == HttpContext.Current.Session.SessionID).FirstOrDefault();    

            //If we dont have any such rows, then it means user is not logged in. Redirect to login page.
            if (result == null) {
                filterContext.Result = new RedirectToRouteResult(
                     new RouteValueDictionary 
                        { 
                            { "controller", "Account" }, 
                            { "action", "Login" } 
                        }
                     );
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}