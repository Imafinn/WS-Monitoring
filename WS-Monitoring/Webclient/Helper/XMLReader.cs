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