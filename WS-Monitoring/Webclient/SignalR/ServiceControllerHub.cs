using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.ServiceProcess;
using Microsoft.AspNet.SignalR.Hubs;
using System.Diagnostics;

namespace Webclient.SignalR
{
    [HubName("serviceController")]
    public class ServiceControllerHub : Hub
    {
        public void StartService(int id)
        {

        }

        public void RestartService(int id)
        {

        }

        public void StopService(int id)
        {

        }

        public void NotifyServerStatusChanged(ServiceController service)
        {
            Clients.All.onServerStatusChange(service);
        }
    }
}