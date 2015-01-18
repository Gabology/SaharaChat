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
        public override System.Threading.Tasks.Task OnConnected()
        {
            Trace.WriteLine("Client connected!!!");
            return base.OnConnected();
        }

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
            Trace.WriteLine(string.Format("INCOMING POSITION FROM: {0}\nPOSITION: {1}", Context.ConnectionId, Tuple.Create(x, y)));
            // Invoke callback in all other clients, informing them of callers GUID and new position
            Clients.Others.updatePositionOf(Context.ConnectionId, x, y);
        }

        public void SayHello()
        {
            Trace.WriteLine("HELLO!!! CONNECTION:  " + Context.ConnectionId);
        }
    }
}