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
        private List<string> ConnectedUsers = new List<string>();
        public override System.Threading.Tasks.Task OnConnected()
        {
            ConnectedUsers.Add(Clients.Caller.UserName);
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

        public void SendPosition(int x, int y, string userName)
        {
            Trace.WriteLine(string.Format("INCOMING POSITION FROM: {0}\nPOSITION: {1}", Context.ConnectionId, Tuple.Create(x, y)));
            // Invoke callback in all other clients, informing them of callers GUID and new position
            Clients.Others.updatePositionOf(userName, x, y);
        }

        public void GetConnections()
        {
            Clients.Caller.printConnections(string.Join(Environment.NewLine, ConnectedUsers));
            
        }

    }
}