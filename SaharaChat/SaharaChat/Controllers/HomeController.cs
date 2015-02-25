using SaharaChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaharaChat.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Exception() {
            throw new Exception("Hej!");
        }
    }
}