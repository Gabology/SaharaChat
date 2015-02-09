using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SaharaChat.Models
{
    public class SaharaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Byte[] Password { get; set; }
        public string SessionID { get; set; }


    }
}

