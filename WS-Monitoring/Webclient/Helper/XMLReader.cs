using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Webclient.Models;

namespace Webclient.Helper
{
    public class XMLReader
    {
        public static List<ServiceExtended> readServices()
        {
            List<ServiceExtended> items = new List<ServiceExtended>();
            using (var reader = new StreamReader("G:/PUBLIC/winflex/text.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<ServiceExtended>),
                    new XmlRootAttribute("services"));
                items = (List<ServiceExtended>)deserializer.Deserialize(reader);
            }

            return items;
        }
    }
}