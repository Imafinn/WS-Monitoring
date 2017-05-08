using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webclient.Models;

namespace Webclient.Helper
{
    public class ServiceRepo : IServiceRepo
    {
        private List<ServiceExtended> _services;

        public ServiceRepo()
        {
            _services = new List<ServiceExtended>();

            _services.Add(new ServiceExtended() { Id = 1, Name = "Service one", Description = "Service eins von vielen.", Status = "Running" });
            _services.Add(new ServiceExtended() { Id = 2, Name = "Service dos", Description = "Service zwei von einigen.", Status = "Stopped" });
        }

        public List<ServiceExtended> GetAll()
        {
            return _services;
        }

        public ServiceExtended Restart(int id)
        {
            ServiceExtended service = _services.First(s => s.Id == id);
            Console.WriteLine("Restarting Service: " + service.Name);
            Console.WriteLine("- " + service.Description);
            Console.WriteLine("- " + service.Status);
            return service;
        }

        public ServiceExtended Start(int id)
        {
            ServiceExtended service = _services.First(s => s.Id == id);
            Console.WriteLine("Starting Service: " + service.Name);
            Console.WriteLine("- " + service.Description);
            Console.WriteLine("- " + service.Status);
            return service;
        }

        public ServiceExtended Stop(int id)
        {
            ServiceExtended service = _services.First(s => s.Id == id);
            Console.WriteLine("Stopping Service: " + service.Name);
            Console.WriteLine("- " + service.Description);
            Console.WriteLine("- " + service.Status);
            return service;
        }
    }
}