using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaharaChat.Models;

namespace SaharaChat.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLoginViewModel viewmodel)
        {
            //Check if we have both required fields (username and password)
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }
            
            //Try to login using our given username and password


            return View();
        }


        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }
    }
}