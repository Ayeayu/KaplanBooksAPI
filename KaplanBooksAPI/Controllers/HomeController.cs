using KaplanBooksAPI.Attribute;
using KaplanBooksAPI.Models;
using KaplanBooksAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KaplanBooksAPI.Controllers
{
    //[ApiKey]
    public class HomeController : Controller
    {
        private readonly IGoogleBookService _googleBookService;

        public HomeController(IGoogleBookService googleBookService)
        {
            _googleBookService = googleBookService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var newReleases = await GetBooks();

            return View(newReleases);
        }

        private async Task<IEnumerable<KaplanBooks>> GetBooks()
        {
            try
            {

                var newReleases = await _googleBookService.GetKaplanBooks();

                return newReleases;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<KaplanBooks>();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
