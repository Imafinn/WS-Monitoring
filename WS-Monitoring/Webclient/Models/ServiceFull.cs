using System;
using System.ServiceProcess;
using System.Management;
using System.Diagnostics;

namespace Webclient.Models
{
    /// <summary>
    /// Information from the ServiceController class about a service to be monitored, 
    /// like a facade for the ServiceController.
    /// </summary>
    public class ServiceFull
    {
        /// <summary>
        /// This constructor parses the ServiceController into the necessary data for this class.
        /// </summary>
        /// <param name="service">ServiceController with valid data.</param>
        public ServiceFull(ServiceController service)
        {
            Service = service;
        }

        /// <summary>
        /// Id property.
        /// </summary>
        /// <value>The id of the service to be monitored.</value>
        public int Id { get; set; }

        /// <summary>
        /// DisplayName property.
        /// </summary>
        /// <value>The name of the service to be shown on the monitor view.</value>
        public string DisplayName
        {
            get
            {
                return Service.DisplayName;
            }
        }

        /// <summary>
        /// ServiceName property.
        /// </summary>
        /// <value>The name of the service from the .xml inputfile.</value>
        public string ServiceName
        {
            get
            {
                return Service.ServiceName;
            }
        }

        /// <summary>
        /// Status property.
        /// </summary>
        /// <value>The status of the service to be monitored.</value>
        public string Status
        {
            get
            {
                return Service.Status.ToString();
            }
        }


        /// <summary>
        /// Description property.
        /// </summary>
        /// <value>The description of the service to be monitored.</value>
        public string Description
        {
            get
            {
                ManagementObject wmiService = new ManagementObject($"Win32_Service.Name='{Service.ServiceName}'");
                wmiService.Get();      

                // No .ToString() for the description, because it could be null and that would cause an exception.
                return (string)wmiService["Description"] ?? "No description avaiable!"; ;
            }
        }

        /// <summary>
        /// An explicit identification property.
        /// </summary>
        /// <value>The Identification is the Id and the Name concatenated and every blank is replaced by an '_'</value>
        public string Identification
        {
            get
            {
                return Id + "_" + Service.ServiceName.Replace(' ', '_').Replace('.', '_');
            }
        }
        /// <summary>
        /// A property to monitor the CPU usage of the service process.
        /// </summary>
        /// <value>Contains a String with the current CPU usage of the service</value>
        public string PerformanceCPU { get; set; }

        /// <summary>
        /// A property to monitor the RAM usage of the service process.
        /// </summary>
        /// <value>Contains a String with the current RAM usage of the service</value>
        public string PerformanceRAM { get; set; }

        /// <summary>
        /// Service property.
        /// </summary>
        /// <value>Contains the associated ServiceController.</value>
        public ServiceController Service { get; set; }
    }
}