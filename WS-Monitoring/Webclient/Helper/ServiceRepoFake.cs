using System;
using System.Collections.Generic;
using System.Linq;
using Webclient.Models;

namespace Webclient.Helper
{
    /// <summary>
    /// DEPRECATED: Do not use!
    /// FakeRepository attends as a MockUp and mustn't be needed in the final solution.
    /// </summary>
    public class ServiceRepoFake : IServiceRepo
    {
        private List<ServiceFull> _services;

        public ServiceRepoFake()
        {
            _services = new List<ServiceFull>();

            //_services.Add(new ServiceFull() { Id = 1, DisplayName = "Service one", ServiceName = "Service one", Status = "stopped", Description = "Ein Service von vielen" });
            //_services.Add(new ServiceFull() { Id = 2, DisplayName = "Service dos", ServiceName = "Service dos", Status = "running", Description = "Ein anderer Service von vielen" });
            //_services.Add(new ServiceFull() { Id = 3, DisplayName = "Service drei", ServiceName = "Service drei", Status = "paused", Description = "Ein anderer Service von einigen" });
        }

        public List<ServiceFull> GetAll()
        {
            return _services;
        }

        public ServiceFull GetServiceById(int id)
        {
            throw new NotImplementedException();
        }

        public void Restart(int id, string name)
        {
            ServiceFull service = _services.First(s => s.Id == id && s.ServiceName.Equals(name));
            Console.WriteLine("Restarting Service: " + service.ServiceName);
        }

        public void Start(int id, string name)
        {
            ServiceFull service = _services.First(s => s.Id == id && s.ServiceName.Equals(name));
            Console.WriteLine("Starting Service: " + service.ServiceName);
        }

        public void Stop(int id, string name)
        {
            ServiceFull service = _services.First(s => s.Id == id && s.ServiceName.Equals(name));
            Console.WriteLine("Stopping Service: " + service.ServiceName);
        }
    }
}