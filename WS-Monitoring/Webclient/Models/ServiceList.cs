using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Webclient.Models
{
    /// <summary>
    /// Contains a list of services to be monitored.
    /// </summary>
    [XmlRoot("services")]
    public class ServiceList
    {
        /// <summary>
        /// Creates a new list of type ServiceExtended
        /// </summary>
        public ServiceList() {
            Items = new List<ServiceXML>();
        }
        /// <summary>
        /// List of Services
        /// </summary>
        /// <value>Contains Services to be monitored</value>
        [XmlElement("service")]
        public List<ServiceXML> Items { get; set; }
    }
}