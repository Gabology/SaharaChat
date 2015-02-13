using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using SaharaChat.Hubs;
[assembly: OwinStartup(typeof(SaharaChat.Startup))]
namespace SaharaChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}