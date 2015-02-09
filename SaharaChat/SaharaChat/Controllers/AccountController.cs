using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaharaChat.Models;
using System.Security.Cryptography;

namespace SaharaChat.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            var viewmodel = new AccountLoginViewModel();

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(AccountLoginViewModel viewmodel)
        {
            //Check if we have both required fields (username and password)
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            var db = new SaharaContext();
            //var num =   db.Users
            //            .Where(u => u.UserName==viewmodel.Username && u.Password == "0x0000007B")
            var allUsers = db.Users.ToList();



            //Try to login using our given username and password
            if (viewmodel.Username == "test" && viewmodel.Password == "123")
            {
                //Login success
                //Set cookie

                return Content("Logged in!");
            } else
            {
                //Failed login
                viewmodel.ErrorMessage = "Wrong login. Try again.";
                return View(viewmodel);
            }

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