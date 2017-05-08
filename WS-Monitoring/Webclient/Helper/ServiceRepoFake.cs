using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webclient.Models;

namespace Webclient.Helper
{
    public class ServiceRepoFake : IServiceRepo
    {
        private List<ServiceExtended> _services;

        public ServiceRepoFake()
        {
            _services = new List<ServiceExtended>();

            _services.Add(new ServiceExtended() { Id = 1, Name = "Service one" });
            _services.Add(new ServiceExtended() { Id = 2, Name = "Service dos" });
        }

        public List<ServiceExtended> GetAll()
        {
            return _services;
        }

        public ServiceExtended Restart(int id)
        {
            ServiceExtended service = _services.First(s => s.Id == id);
            Console.WriteLine("Restarting Service: " + service.Name);
            return service;
        }

        public ServiceExtended Start(int id)
        {
            ServiceExtended service = _services.First(s => s.Id == id);
            Console.WriteLine("Starting Service: " + service.Name);
            return service;
        }

        public ServiceExtended Stop(int id)
        {
            ServiceExtended service = _services.First(s => s.Id == id);
            Console.WriteLine("Stopping Service: " + service.Name);
            return service;
        }
    }
}