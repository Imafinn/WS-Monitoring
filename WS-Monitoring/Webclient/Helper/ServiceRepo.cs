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
        private List<ServiceExtended> _servicesBasic;
        /// <summary>
        /// List received by the ServiceController, it contains the extended services.
        /// </summary>
        private List<ServiceExtended> _servicesExtended;

        /// <summary>
        /// In the Constructor the servicelists get initalized.
        /// </summary>
        public ServiceRepo()
        {
            _servicesBasic = XMLReader.ReadServices();
        }

        public List<ServiceExtended> GetAll()
        {
            return _servicesBasic;
        }

        public ServiceExtended Restart(int id)
        {
            ServiceExtended service = _servicesBasic.First(s => s.Id == id);

            return service;
        }

        public ServiceExtended Start(int id)
        {
            ServiceExtended service = _servicesBasic.First(s => s.Id == id);

            return service;
        }

        public ServiceExtended Stop(int id)
        {
            ServiceExtended service = _servicesBasic.First(s => s.Id == id);

            return service;
        }
    }
}