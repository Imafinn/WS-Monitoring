using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Webclient.Models
{
    [XmlRoot("services")]
    public class ServiceList
    {
        public ServiceList() {
            Items = new List<ServiceExtended>();
        }
        [XmlElement("service")]
        public List<ServiceExtended> Items { get; set; }
    }
}