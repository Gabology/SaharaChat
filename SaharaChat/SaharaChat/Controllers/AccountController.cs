using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaharaChat.Models;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

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

            //Try to login using our given username and password
            if (db.VerifyAccount(viewmodel.Username, viewmodel.Password))
            {
                //Login success
                //Set cookie

                var user = db.Users.Where(u => u.UserName == viewmodel.Username).FirstOrDefault();

                //Session.SessionID does always seem to exist
                user.SessionID = Session.SessionID;
                db.SaveChanges();

                //We need to put something in our Session, otherwise the client will not get a SessionID cookie back.
                //We enter our username in the session.
                Session["UserName"] = viewmodel.Username;
                return RedirectToAction("Index", "Game");
            } else
            {

                //Failed login
                ModelState.AddModelError(String.Empty, "Wrong credentials. Try again.");    //String.Empty apparently makes the error show up in ValidationSummary...
                return View(viewmodel);
            }

        }




        public ActionResult Logout()
        {
            Session.Abandon();  //Remove Session
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));  //Force a new session id onto the user
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Signup()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Signup(CreateAccountViewModel model)
        {
            if (!model.SamePassword)
                ModelState.AddModelError("RepeatPassword", "Det här blev ju inte rätt");

            if(!ModelState.IsValid)
                return View(model);

            //Todo: peta in usér i db

            return RedirectToAction("Login", "Account");
        }
    }
}