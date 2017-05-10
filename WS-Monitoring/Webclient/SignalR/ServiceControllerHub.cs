using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.ServiceProcess;

namespace Webclient.SignalR
{
    public class ServiceControllerHub : Hub
    {
        public void UpdateService(ServiceController service)
        {
            Clients.All.onServerUpdate(service);
        }
    }
}