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
        private bool VerifyAccount(string u, string p)
        {
            SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=SaharaDB");
            SqlCommand cmd = new SqlCommand();
            Object returnValue;

            cmd.CommandText = "VerifyAccount";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            cmd.Parameters.Add(new SqlParameter("AccountName", u));
            cmd.Parameters.Add(new SqlParameter("AccountPwd", p));


            sqlConnection1.Open();

            returnValue = cmd.ExecuteScalar();

            sqlConnection1.Close();


            return (int)returnValue == 1 ? true : false;

        }

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

            //var db = new SaharaContext();
            //var num =   db.Users
            //            .Where(u => u.UserName==viewmodel.Username && u.Password == "0x0000007B")
            //var verify = db.Database.SqlQuery<int>("dbo.VerifyAccount @AccountName, @AccountPwd", new SqlParameter("AccountName", viewmodel.Username), new SqlParameter("AccountPwd", viewmodel.Password));
            //bool verified = verify;

            var result = VerifyAccount(viewmodel.Username, viewmodel.Password);

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