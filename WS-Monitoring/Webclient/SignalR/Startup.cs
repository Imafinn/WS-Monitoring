using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Webclient.SignalR.Startup))]
namespace Webclient.SignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}