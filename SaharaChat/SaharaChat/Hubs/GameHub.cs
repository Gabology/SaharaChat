using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;
using SaharaChat.Models;

namespace SaharaChat.Hubs
{
    public class GameHub : Hub
    {
        private static List<string> log = new List<string>();
        private static SaharaContext db = new SaharaContext();

        private string GetCallerUserName()
        {
            var sessId = Context.RequestCookies["ASP.NET_SessionID"].Value;
            return db.Users.SingleOrDefault(user => user.SessionID == sessId).UserName;
        }

        private void Log(string input)
        {
            log.Add(string.Format("[{0}] {1}", DateTime.Now, input));
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            Log("Client connected: " + GetCallerUserName());
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            Log("Client disconnected: " + GetCallerUserName());
            return base.OnDisconnected(stopCalled);
        }

        public void SendPosition(double x, double y)
        {
            var client = GetCallerUserName();
            Log(string.Format("Incoming request from {0} move to: {1}", client, Tuple.Create(x, y)));
            
            // Invoke callback in all other clients, informing them of callers GUID and new position
            Clients.Others.updatePositionOf(client, x, y);
        }

        public void SendMessage(string msg) {
            Clients.All.printMessage(GetCallerUserName() + ": " + msg);
        }

        public void GetLog()
        {
            Clients.Caller.printLog(Newtonsoft.Json.JsonConvert.SerializeObject(log));
        }
    }
}