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
        //User our custom action filter attribute called LoginFilter
        [LoginFilter]   
        public ActionResult Index()
        {
            //Let the games begin!

            return View();
        }
    }
}