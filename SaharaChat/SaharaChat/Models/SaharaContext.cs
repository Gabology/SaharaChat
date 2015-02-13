using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;

namespace SaharaChat.Models
{
    public class SaharaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public bool VerifyAccount(string userName, string password) {

            var res = Database.SqlQuery<int?>("dbo.VerifyAccount @AccountName, @AccountPwd", 
                new SqlParameter("AccountName", userName), new SqlParameter("AccountPwd", password))
                .SingleOrDefault();

            return res.HasValue;
        }
    }



    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Byte[] Password { get; set; }
        public string SessionID { get; set; }
        public string Color { get; set; }


    }


}

