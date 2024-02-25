using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ToolsController : Controller
    {
        readonly StoreContext context;
        readonly BudgetRepository budgetRepository;

        public ToolsController(IConfiguration configuration, StoreContext context)
        {
            this.context = context;
            budgetRepository = new BudgetRepository(configuration);
        }
        public IActionResult Index() => View(context.BudgetModels.ToList());
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BudgetModel obj)
        {
            int ret = budgetRepository.Add(obj);
            return Redirect("/auth");
        }
        [HttpPost]
        public IActionResult Update(BudgetModel obj, short id)
        {
            obj.Id = id;
            if (budgetRepository.Update(obj) > 0)
            {
                return Redirect("/auth");
            }
            else
            {
                return Redirect("/auth/error");
            }

        }
        public IActionResult Delete(short id)
        {
            if (budgetRepository.Delete(id) > 0)
            {
                return Redirect("/auth");
            }
            return Redirect("/auth/error");

        }
        public IActionResult Update(short id)
        {
            return View(budgetRepository.GetBudgets(id));
        }
    }
}
