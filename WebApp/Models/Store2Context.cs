using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebApp.Models
{
    public class Store2Context : DbContext
    {
        //init a new identity  context 
        public Store2Context(DbContextOptions<Store2Context> options) : base(options)
        {
        }
        //this one is used to query and save instances
        public DbSet<TransModel> TransModels { get; set; } = null!;
        public DbSet<CategoryModel> CategoryModels { get; set; } = null!;


    }
}