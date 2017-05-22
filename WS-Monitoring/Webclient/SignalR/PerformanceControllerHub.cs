using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.ServiceProcess;
using Microsoft.AspNet.SignalR.Hubs;
using System.Diagnostics;
using Webclient.Models;
using Webclient.Helper;
using Ninject;
using System.Reflection;
using Newtonsoft.Json;

namespace Webclient.SignalR
{
    /// <summary>
    /// Not in use yet.
    /// </summary>
    [HubName("performanceController")]
    public class PerformanceControllerHub : Hub
    {
        private IPerformanceTimer _timer;

        public PerformanceControllerHub()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            _timer = kernel.Get<IPerformanceTimer>();
        }

        public void NotifyServiceStatusChanged()
        {
            Clients.All.onPerformanceChange();
        }

    }
}