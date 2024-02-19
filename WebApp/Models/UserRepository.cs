using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

//naive     
namespace WebApp.Models;

    public class UserRepository
    {
        readonly string connectionString;
        readonly UserManager<IdentityUser> manager;
         public UserRepository(UserManager<IdentityUser> manager,IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Finance") ?? throw new InvalidOperationException("Not found");
            this.manager = manager; 

        }

    public UserRepository(UserManager<IdentityUser> manager)
    {
        this.manager = manager;
    }

    //get user function
    public List<IdentityUser> GetUsers()
        {
            return manager.Users.ToList();
        }

        public async Task<IdentityResult> Add(RegisterModel obj)
        {
            var user = new IdentityUser
            {
                UserName = obj.UserName,
                Email = obj.Email,
                PhoneNumber = obj.Phone
            };                                                                                                                                      
            return await manager.CreateAsync(user, obj.Password);
        }

        //? sometimes the values can be null
        public async Task<IdentityUser?> Login(LoginModel obj)
        {
            var user = await manager.FindByNameAsync(obj.U);
            if (user != null)
            {
                if (await manager.CheckPasswordAsync(user, obj.P))
                {
                    return user;
                }
            }
            return null;
        }




            //using Dapper
        //Add products here
        //public int Add(BudgetModel obj)
        //{
        //    string sql = "INSERT INTO Buget(Id,Name,Description,Price,Quantity) VALUES(@id,@name ,@description,@price,@quantity)";
        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //    return connection.Execute(sql, new { id = obj.Id,name=obj.Name,description=obj.Description,price=obj.Price,quantity=obj.Quantity});
        //    }
                    
        //}


    }
