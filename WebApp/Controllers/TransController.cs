using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class TransController : Controller
    {
        readonly Store2Context context;
        private readonly TransRepository transRepository;
        private readonly CategoryRepository categoryRepository;
        public TransController(Store2Context context, IConfiguration configuration)
        {
            this.context = context;
            transRepository = new TransRepository(configuration);
            categoryRepository = new CategoryRepository(configuration);
        }
        public IActionResult Index()
        {
            var viewModel = new ViewModel()
            {
                TransModels = context.TransModels.ToList(),
                CategoryModels = context.CategoryModels.ToList()
            };
            return View(viewModel);
        }

        public IActionResult Category()
        {
            var categoryModel = context.CategoryModels.ToList();
            return View(categoryModel);
        }
    }
}
