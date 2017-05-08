using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webclient.Models;

namespace Webclient.Helper
{
    public class ServiceRepo : IServiceRepo
    {
        private List<ServiceExtended> _servicesBasic;
        //private List<ServiceExtended> _servicesExtended;

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