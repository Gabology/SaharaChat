using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SaharaChat.Hubs
{
    public class GameHub : Hub
    {
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {

             return base.OnDisconnected(stopCalled);
        }

        public void SendMessage(string message)
        {
            var connectionId = Context.ConnectionId;
            Clients.Others.displayMessage(connectionId, message);
        }

        public void SendPosition(int x, int y)
        {

        }
    }
}