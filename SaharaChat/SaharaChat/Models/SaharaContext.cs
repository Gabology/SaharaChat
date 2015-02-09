using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace SaharaChat.Models
{
    public class SaharaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        /*
        [Function(Name="dbo.VerifyAccount")]
        [return: Parameter(DbType="Int")]
        public int VerifyAccount([Parameter(Name="AccountName", DbType="VARCHAR(50)")] string AccountName, [Parameter(Name="AccountPwd", DbType="VARCHAR(100)")] string AccountPwd)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), customerID, totalSales);
            totalSales = ((System.Nullable<decimal>)(result.GetParameterValue(1)));
            return ((int)(result.ReturnValue));
        }*/
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

