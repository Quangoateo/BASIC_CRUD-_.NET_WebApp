using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ToolsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
