using Microsoft.AspNetCore.Mvc;

namespace KaplanBooksAPI.Controllers
{
    public class Creators : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
