using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TransController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
