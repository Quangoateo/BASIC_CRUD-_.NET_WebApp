using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApp.Models;

namespace WebApp.Controllers ;
    public class AuthController : Controller
    {
       readonly StoreContext context;
       readonly UserRepository  userRepository;
       readonly BudgetRepository budgetRepository;
       readonly SignInManager<IdentityUser> signInManager;

    public AuthController(UserManager<IdentityUser> manager, SignInManager<IdentityUser> signInManager, StoreContext context, IConfiguration configuration)
    {
        budgetRepository = new BudgetRepository(configuration);
        userRepository = new UserRepository(manager);
        this.signInManager = signInManager;
        this.context = context;

    }
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

    public IActionResult Delete(short id)
    {
        if(budgetRepository.Delete(id)>0)
        {
            return Redirect("/auth");
        }
        return Redirect("/auth/error");

    }
    //authorise to "auth" page
    [Authorize] 
    public IActionResult Index() => View(context.BudgetModels.ToList());
    public IActionResult Login() => View();
    public IActionResult Register() => View();
  
    public IActionResult Update(short id)
    {
        return View(budgetRepository.GetBudgets(id));
    }


    [HttpPost]
    
    
    public IActionResult Update(BudgetModel obj,short id) {
        obj.Id = id;
        if(budgetRepository.Update(obj)>0)
        {
            return Redirect("/auth");
        }
        else
        {
            return Redirect("/auth/error");
        }

    }
       
    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel obj)
    {
        if (ModelState.IsValid)
        {
            var result = await userRepository.Add(obj);
            if (result.Succeeded)
            {
                return Redirect("/auth/login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("error", error.Description);
                }
            }
        }
        else
        {
            ModelState.AddModelError("error", "Please input!");
        }
        return View(obj);
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel obj)
    {
        var user = await userRepository.Login(obj);
        if (user != null)
        {
            var result = await signInManager.PasswordSignInAsync(user, obj.P, obj.R, true);
            if (result.Succeeded)
            {
                return Redirect("/auth");
            }
            else
            {
                ModelState.AddModelError("error","Login Invalid");
            }
        }
        ModelState.AddModelError("error","user or password invalid");
        return View(obj);
    }



}
