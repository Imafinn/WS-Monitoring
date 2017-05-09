using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Webclient.Models;

namespace Webclient.Helper
{
    /// <summary>
    /// Reads a Xml File.
    /// </summary>
    public class XMLReader
    {
        /// <summary>
        /// Reads a Xml File and Serializes it into the ServiceExtended class.
        /// </summary>
        /// <returns>A list containing information about services to be monitored.</returns>
        public static List<ServiceExtended> ReadServices()
        {
            ServiceList list = new ServiceList();
            List<ServiceExtended> items = new List<ServiceExtended>();
            using (var reader = new StreamReader("G:/PUBLIC/winflex/test.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(ServiceList),
                    new XmlRootAttribute("services"));
                list = (ServiceList)deserializer.Deserialize(reader);
            }
            
            return list.Items;
        }
    }
}