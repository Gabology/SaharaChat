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
            Cookie sessionId;
            if (request.Cookies.TryGetValue("ASP.NET_SessionID", out sessionId))
                return
                    _db.Users
                    .SingleOrDefault(user => user.SessionID == sessionId.Value)
                    .UserName;
            else
                return string.Empty;
        }
    }
}