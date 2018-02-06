using CustomersIndex.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class ClientsTest
    {
        [TestMethod]
        public void BusinessClientTest()
        {
            BusinessClient client = new BusinessClient(1,"firma", "państwo", "miasto", "ulica", "numer", "telefon", "mail");

            Assert.IsTrue(client.IsBusinessClient);
        }

        [TestMethod]
        public void IndividualClientTest()
        {
            IndividualClient client = new IndividualClient(1,"firma", "państwo", "miasto", "ulica", "numer", "telefon", "mail");

            Assert.IsFalse(client.IsBusinessClient);
        }
    }
}
