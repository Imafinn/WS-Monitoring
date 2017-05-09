using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceControllerClientTest
{
    class Program
    {
        static string[] services = { "netprofm", "ose", "PerfHost", "cmd" };
        static void Main(string[] args)
        {
            foreach (var proc in Process.GetProcesses())
            {
                GetService(proc.Id, proc.ProcessName);
                //Console.ReadKey();
            }
            Console.ReadKey();
        }

        private static ServiceController GetService(int id, string name)
        {
            //Console.WriteLine($"ID:{id},NAME:{name}.");
            Process match = null;
            try
            {
                Process[] processes = Process.GetProcessesByName(name);
                foreach (var p in processes)
                {
                    //Console.WriteLine($"  ID:{p.Id}");
                    if (p.Id == id)
                        match = p;
                }
            }
            catch (ArgumentException)
            {
                //Console.WriteLine("Something went wrong");
                Console.ReadKey();
            }

            List<ServiceController> matchingServices = new List<ServiceController>();
            if (match != null)
            {
                matchingServices = ServiceController.GetServices()
                                                    .Where(sc => sc.ServiceName.Equals(match.ProcessName))
                                                    .ToList();
            }

            if (matchingServices.Count == 1)
            {
                Console.WriteLine($"ID:{id},NAME:{name}");
                Console.WriteLine($"=>{matchingServices[0].DisplayName}");
                Console.WriteLine(new string('-', 25));
                //Console.ReadKey();
                return matchingServices[0];
            }
            else if (matchingServices.Count == 0)
            {
                //Console.WriteLine($"No Services found for ID '{id}'");
                return null;
            }
            else
            {
                throw new ArgumentException($"Found more than one Service with the ID '{id}'");
            }
        }
    }
}