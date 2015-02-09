using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaharaChat.Models;


namespace SaharaChat.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            var db = new SaharaContext();

            var result = db.Users.Where(u => u.SessionID == Session.SessionID).FirstOrDefault();
            if (result == null) return Content("Not logged in");


            return View();
        }
    }
}