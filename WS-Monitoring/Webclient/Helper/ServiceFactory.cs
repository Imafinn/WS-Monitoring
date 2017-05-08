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

        public ServiceController GetService(int id)
        {
            string processName = Process.GetProcessById(id).ProcessName;
            List<ServiceController> matchingServices = ServiceController.GetServices()
                                                                        .Where(sc => sc.ServiceName.Equals(processName))
                                                                        .ToList();

            if(matchingServices.Count == 1)
            {
                return matchingServices[0];
            }
            else if(matchingServices.Count == 0)
            {
                throw new ArgumentException($"No Services found with the ID '{id}'");
            }
            else
            {
                throw new ArgumentException($"Found more than one Service with the ID '{id}'");
            }
        }
	}
}