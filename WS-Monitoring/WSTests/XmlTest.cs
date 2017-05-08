using System;
using Webclient.Helper;
using NUnit.Framework;
using System.Collections.Generic;
using Webclient.Models;

namespace WSTests
{
    [TestFixture]
    public class XmlTests
    {
        [Test]
        public void ShouldReadXmlFile()
        {
            List<ServiceExtended> list = new List<ServiceExtended>();
            list = XMLReader.ReadServices();
            Assert.That(list.Count, Is.EqualTo(2));
        }
    }
}
