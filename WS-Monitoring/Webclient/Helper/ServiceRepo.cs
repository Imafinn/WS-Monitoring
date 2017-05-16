using System.Collections.Generic;
using System.ServiceProcess;
using System.Linq;
using Webclient.Models;
using System.Diagnostics;

namespace Webclient.Helper
{
    /// <summary>
    /// ServiceRepo executes the different actions with services.
    /// </summary>
    public class ServiceRepo : IServiceRepo
    {
        /// <summary>
        /// List received by the XMLReader, it contains the basic services.
        /// </summary>
        private List<ServiceXML> _servicesBasic;
        /// <summary>
        /// List received by the ServiceController, it contains the extended services.
        /// </summary>
        private List<ServiceFull> _servicesExtended;
        private ServiceFactory _serviceFactory;

        /// <summary>
        /// In the Constructor the servicelists get initalized.
        /// </summary>
        public ServiceRepo()
        {
            _servicesBasic = XMLReader.ReadServices();
            _servicesExtended = new List<ServiceFull>();
            _serviceFactory = new ServiceFactory();

            foreach (ServiceXML sXML in _servicesBasic)
            {
                foreach (ServiceController s in _serviceFactory.GetServices(sXML.Name))
                {
                    _servicesExtended.Add(new ServiceFull(s) { Id = _servicesExtended.Count + 1 });
                }
            }
            //foreach (ServiceController s in _serviceFactory.GetAllServices())
            //{
            //    _servicesExtended.Add(new ServiceFull(s) { Id = _servicesExtended.Count + 1 });
            //}
        }

        public List<ServiceFull> GetAll()
        {
            return _servicesExtended;
        }

        public ServiceFull GetServiceById(int id)
        {
            return _servicesExtended.Where(s => s.Id == id).First();
        }

        public void Restart(int id, string name)
        {
            ServiceController service = ReceiveCurrentServiceController(id, name);
            service.Stop();
            service.WaitForStatus(ServiceControllerStatus.Stopped);
            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running);
            service.Refresh();
        }

        public ServiceControllerStatus Start(int id, string name)
        {
            ServiceController service = ReceiveCurrentServiceController(id, name);
            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running);
            service.Refresh();
            return service.Status;
        }

        public ServiceControllerStatus Stop(int id, string name)
        {
            ServiceController service = ReceiveCurrentServiceController(id, name);
            service.Stop();
            service.WaitForStatus(ServiceControllerStatus.Stopped);
            service.Refresh();
            return service.Status;
        }

        /// <summary>
        /// Internal method to receive the current ServiceController.
        /// </summary>
        /// <param name="id">Id of the current service.</param>
        /// <param name="name">Name of the service.</param>
        /// <returns>Returns the current ServiceController.</returns>
        private ServiceController ReceiveCurrentServiceController(int id, string name)
        {
            return _servicesExtended.Where(s => s.Id == id && s.ServiceName.Equals(name)).First().Service;
        }
    }
}