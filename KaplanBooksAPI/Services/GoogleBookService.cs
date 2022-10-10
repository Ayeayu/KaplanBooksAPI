using KaplanBooksAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace KaplanBooksAPI.Services
{
    

    public class GoogleBookService : IGoogleBookService
    {
        private  readonly HttpClient _httpClient;
        //public readonly string _url = "/books/v1/volumes?q=kaplan%20test%20prep";

        public GoogleBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       

        public async Task<IEnumerable<KaplanBooks>> GetKaplanBooks()
        {
            //var yourAPIKey = "AIzaSyBwidUQB-D56TS_76nLTLDzOxZOxCm1s5c";
            //var url = "https://www.googleapis.com/books/v1/volumes?q=kaplan%20test%20prep";

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);


            //var response = await _httpClient.GetAsync($"volumes?author={author}&title={title}:&key={yourAPIKey}");

            response.EnsureSuccessStatusCode();
            List<List<KaplanBooks>> kaplanBooks = new List<List<KaplanBooks>>();
            using var resposneStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetBookResult>(resposneStream);

            
            return responseObject?.items?.Select(x => new KaplanBooks
            {
                Title = x.volumeInfo.title,
                Author = string.Join(",", x.volumeInfo.authors),
                Publisher = x.volumeInfo.publisher,
                PublishedDate = x.volumeInfo.publishedDate,
                ImageUrl = x.volumeInfo.imageLinks.thumbnail,
                Link = x.volumeInfo.infoLink,
            }) ;

           

        }
    }
}
