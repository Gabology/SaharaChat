using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaharaChat.Models;


namespace SaharaChat.Controllers
{
    [HandleError]
    public class GameController : Controller
    {
        // GET: Game
        //User our custom action filter attribute called LoggedInFilter
        [LoggedInFilter]   
        public ActionResult Index()
        {
            var db = new SaharaContext();

            // Instantiate an avatar containing logged in user as name and color as color
            var sess = Request.Cookies["ASP.NET_SessionID"].Value;
            var user = db.Users.SingleOrDefault(u => u.SessionID == sess);
            var avatar = new Avatar(user.UserName, user.Color);

            //Let the games begin!
            return View(avatar);
        }
    }
}