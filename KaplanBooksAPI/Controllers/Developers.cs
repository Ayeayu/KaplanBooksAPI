using Microsoft.AspNetCore.Mvc;

namespace KaplanBooksAPI.Controllers
{
    public class Developers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
