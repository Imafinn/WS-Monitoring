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

namespace Webclient.SignalR
{
    [HubName("serviceController")]
    public class ServiceControllerHub : Hub
    {
        private IServiceRepo _repo;
        public static ServiceControllerHub serviceControllerHub;

        public ServiceControllerHub()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            _repo = kernel.Get<IServiceRepo>();
            serviceControllerHub = this;
        }

        public void StartService(int id)
        {
            ServiceFull service = _repo.GetAll().Where(s => s.Id.Equals(id)).First();
            string name = service.ServiceName;
            ServiceControllerStatus status = _repo.Start(id, name);
            NotifyServiceStatusChanged(id, status);
        }

        public void RestartService(int id)
        {
            ServiceFull service = _repo.GetAll().Where(s => s.Id.Equals(id)).First();
            string name = service.ServiceName;
            ServiceControllerStatus status = _repo.Stop(id, name);
            NotifyServiceStatusChanged(id, status);
            status = _repo.Start(id, name);
            NotifyServiceStatusChanged(id, status);
        }

        public void StopService(int id)
        {
            ServiceFull service = _repo.GetAll().Where(s => s.Id.Equals(id)).First();
            string name = service.ServiceName;
            ServiceControllerStatus status = _repo.Stop(id, name);
            NotifyServiceStatusChanged(id, status);
        }

        public void NotifyServiceStatusChanged(int id, ServiceControllerStatus status)
        {
            Clients.All.onServiceStatusChanged(id, status.ToString());
        }
        public void NotifyPerformanceChanged(ServiceFull service)
        {
            Clients.All.onPerformanceChanged(service.Id, service.PerformanceCPU, service.PerformanceRAM);
        }

        public void StartTimer()
        {

        }
    }
}