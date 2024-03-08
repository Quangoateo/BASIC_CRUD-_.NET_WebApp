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
       readonly SignInManager<IdentityUser> signInManager;
    public AuthController(UserManager<IdentityUser> manager, SignInManager<IdentityUser> signInManager, StoreContext context, IConfiguration configuration)
    {
        userRepository = new UserRepository(manager);
        this.signInManager = signInManager;
        this.context = context;
    }
    public IActionResult Index() => View();

    //authorise to "auth" page
    [Authorize]
    public IActionResult Login() => View();
    public IActionResult Register() => View();
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
}
