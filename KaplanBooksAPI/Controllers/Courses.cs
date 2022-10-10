using Microsoft.AspNetCore.Mvc;

namespace KaplanBooksAPI.Controllers
{
    public class Courses : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
