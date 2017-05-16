﻿using System;
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

namespace Webclient.SignalR.Performance
{
    [HubName("performanceController")]
    public class PerformanceControllerHub : Hub
    {
        private IServiceRepo _repo;

        public PerformanceControllerHub()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            _repo = kernel.Get<IServiceRepo>();
        }

        public string GetServiceById(int id)
        {
            return JsonConvert.SerializeObject(_repo.GetAll().Where(s => s.Id == id).First());
        }
    }
}