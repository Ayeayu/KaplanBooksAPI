using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace KaplanBooksAPI.Test
{
    public class UnitTest1
    {

        private static readonly HttpClient _client;

        static UnitTest1()
        {
            _client = new HttpClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task GetAllBooksFromURL(string method)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "https://www.googleapis.com/books/v1/volumes?q=kaplan%20test%20prep");

            //Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);















            //private readonly HttpClient httpClient; 

            //public  UnitTest1()
            //{
            //    var appFactory = new WebApplicationFactory<Startup>();
            //    httpClient = appFactory.CreateClient();

            //}

            //[Fact]
            //public async Task Test1()
            //{
            //    var response = await httpClient.GetAsync("https://www.googleapis.com/books/v1/volumes?q=kaplan%20test%20prep");
            //}

        }
    }
}
