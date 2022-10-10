using Microsoft.AspNetCore.Mvc;

namespace KaplanBooksAPI.Controllers
{
    public class Publishers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
