using Microsoft.AspNet.SignalR;
using SaharaChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaharaChat.Hubs
{
    public class UserIdProvider : IUserIdProvider
    {
        private readonly SaharaContext _db = new SaharaContext();

        public string GetUserId(IRequest request)
        {
            return 
                _db.Users
                .SingleOrDefault(user => user.SessionID == request.Cookies["ASP.NET_SessionID"].Value)
                .UserName;
        }
    }
}