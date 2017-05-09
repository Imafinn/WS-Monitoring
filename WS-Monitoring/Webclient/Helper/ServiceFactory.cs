using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.ServiceProcess;

namespace Webclient.Helper
{
	public class ServiceFactory
	{
        public ServiceFactory()
        {

        }

        public ServiceController GetService(int id, string name)
        {
            Process match = null;
            try
            {
                Process[] processes = Process.GetProcessesByName(name);
                foreach (var p in processes)
                {
                    if (p.Id == id)
                    {
                        match = p;
                        break;
                    }
                }
            }
            catch (ArgumentException) { }

            List<ServiceController> matchingServices = new List<ServiceController>();
            if (match != null)
            {
                matchingServices = ServiceController.GetServices()
                                                    .Where(sc => sc.ServiceName.Equals(match.ProcessName))
                                                    .ToList();
            }

            if (matchingServices.Count == 1)
            {
                return matchingServices[0];
            }
            else if (matchingServices.Count == 0)
            {
                throw new ArgumentException($"Found no Service with the ID '{id}'");
            }
            else
            {
                throw new ArgumentException($"Found more than one Service with the ID '{id}'");
            }
        }

	}
}