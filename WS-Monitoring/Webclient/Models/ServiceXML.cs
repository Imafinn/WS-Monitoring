using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Webclient.Models
{
    /// <summary>
    /// Information from the .xml input about a service to be monitored.
    /// </summary>
    public class ServiceXML
    {
        /// <summary>
        /// Id property.
        /// </summary>
        /// <value>The id of the service to be monitored.</value>
        [XmlElement("id")]
        public int Id { get; set; }
        /// <summary>
        /// Name property.
        /// </summary>
        /// <value>The name of the service to be monitored.</value>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}