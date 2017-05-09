using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Webclient.Models;

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

            foreach (ServiceXML s in _servicesBasic)
            {
                _servicesExtended.Add(new ServiceFull(_serviceFactory.GetService(s.Id, s.Name)) { Id = s.Id });
            }
        }

        public List<ServiceFull> GetAll()
        {
            return _servicesExtended;
        }

        public ServiceFull Restart(int id)
        {
            ServiceFull service = _servicesExtended.First(s => s.Id == id);

            return service;
        }

        public ServiceFull Start(int id)
        {
            ServiceFull service = _servicesExtended.First(s => s.Id == id);

            return service;
        }

        public ServiceFull Stop(int id)
        {
            ServiceFull service = _servicesExtended.First(s => s.Id == id);

            return service;
        }
    }
}