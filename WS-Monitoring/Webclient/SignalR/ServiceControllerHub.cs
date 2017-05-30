using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.ServiceProcess;
using Microsoft.AspNet.SignalR.Hubs;
using System.Diagnostics;
using Webclient.Helper;
using Ninject;
using System.Reflection;
using Axa.iWARP.Database.DTO.Domain.Xiwarp;

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
            _repo.ChangeStatus(id, ChangeStatusTo.Start);
            // NotifyServiceStatusChanged
        }

        public void RestartService(int id)
        {
            _repo.ChangeStatus(id, ChangeStatusTo.Restart);
            // NotifyServiceStatusChanged
        }

        public void StopService(int id)
        {
            _repo.ChangeStatus(id, ChangeStatusTo.Stop);
            // NotifyServiceStatusChanged
        }

        public void NotifyServiceStatusChanged(int id, Enum newStatus)
        {
            Clients.All.onServiceStatusChanged(id, newStatus.ToString());
        }
        public void NotifyPerformanceChanged(Service service)
        {
            //Clients.All.onPerformanceChanged(service.Id, service.PerformanceCPU, service.PerformanceRAM, service.ServiceName);
        }
    }
}