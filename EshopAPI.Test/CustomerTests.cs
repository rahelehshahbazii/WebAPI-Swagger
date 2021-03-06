using EshopAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;

namespace EshopAPI.Test
{
   [TestClass]
    public class CustomerTests
    {
        private HttpClient _client;

        public CustomerTests()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }


        [TestMethod]
        public void CustomerGetAllTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), "/Api/Customers");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        [DataRow(7)]
        public void CustomerGetOneTest(int id)
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), $"/Api/Customers/{id}");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        public void CustomerPostTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("Post"), $"/Api/Customers");

            var response = _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [TestMethod]
        [DataRow(7)]
        public void CustomerPutTest(int id)
        {
            var request = new HttpRequestMessage(new HttpMethod("Put"), $"/Api/Customers/{id}");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }
        [TestMethod]
        [DataRow(9)]
        public void CustomerDeleteTest(int id)
        {
            var request = new HttpRequestMessage(new HttpMethod("Delete"), $"/Api/Customers/{id}");
            var response = _client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

