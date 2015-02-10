using SaharaChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaharaChat.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var db = new SaharaContext();
            db.VerifyAccount("bullshit", "accu");
            return View();
        }
    }
}