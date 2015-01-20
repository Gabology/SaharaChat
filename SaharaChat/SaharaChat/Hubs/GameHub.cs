using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

namespace SaharaChat.Hubs
{
    public class GameHub : Hub
    {
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            Trace.Write("Client disconnected!");
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

        public void SayHello()
        {
            Trace.Write("HELLO!!!  ");
        }
    }
}