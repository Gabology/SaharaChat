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
        //User our custom action filter attribute called LoggedInFilter
        [LoggedInFilter]   
        public ActionResult Index()
        {
            //Let the games begin!
            ViewBag.UserName = Session["UserName"];
            return View();
        }
    }
}