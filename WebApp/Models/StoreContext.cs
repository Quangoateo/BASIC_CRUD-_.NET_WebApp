using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebApp.Models
{
    public class StoreContext : IdentityDbContext
    {
        //init a new identity  context 
        public StoreContext(DbContextOptions<StoreContext> options) : base(options){
        }
        //this one is used to query and save instances
        public DbSet<BudgetModel> BudgetModels { get; set; } = null!;
    }
}
