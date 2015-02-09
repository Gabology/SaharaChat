using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Data.Entity.Core.Objects;

namespace SaharaChat.Models
{
    public class SaharaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ObjectContext ObjectContext { get { return (this as IObjectContextAdapter).ObjectContext ?? null; } }

        public bool VerifyAccount(string userName, string password) {
            var res = ObjectContext.ExecuteFunction<Nullable<int>>
                ("dbo.VerifyAccount", 
                new ObjectParameter("AccountName", userName), 
                new ObjectParameter("AccountPwd", password))
                .SingleOrDefault();

            if(res.HasValue)
                return (res == 1) ? true : false
            else
                // Not sure if we should throw an exception here, maybe we should just return false???
                throw new Exception("Account name does not exist in db!")
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

