using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
//CreateBuilder and ConnectionStrings
var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("Finance") ?? throw new InvalidOperationException("Not found database");


//Configure database Context
builder.Services.AddDbContext<StoreContext>(p => p.UseSqlServer(connectionString));
//user identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<StoreContext>();
//simplify password


//Configure Password Policy
builder.Services.Configure<IdentityOptions>(p =>
{
    p.Password.RequireDigit = false;
    p.Password.RequiredLength = 3;
    p.Password.RequireLowercase = false;
    p.Password.RequireUppercase = false;
    p.Password.RequiredUniqueChars = 1; 
});


//Configure MVC and run applications

builder.Services.AddMvc();
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
//these lines add MVC services to the application,build the application,enable static files
//,define a default controller route ,and run the application.

