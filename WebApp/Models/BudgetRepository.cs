using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
namespace WebApp.Models
{
    public class BudgetRepository
    {
        readonly string connectionString;
        public BudgetRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Finance") ?? throw new InvalidOperationException("Finance database Not found");
        }

        public BudgetModel GetBudgets(short id)
        {
            string sql = "SELECT * FROM Budget WHERE ID  = @Id";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<BudgetModel>(sql, new { Id = id });
            }
        }

        //add functions for budget page ( sql to database here)

        public int Add( BudgetModel obj)
        {
            //check if the 'name' property  is not null
            //if ( obj.Name == null )
            //{
            //    throw new ArgumentNullException(nameof(obj.Name), "Name can not be null");
            //}

            string sql = "INSERT INTO Budget(Name,Description,Price ,Quantity) VALUES(@name,@description,@price,@quantity)  ";
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                return conn.Execute(sql, new { name = obj.Name, description = obj.Description, price = obj.Price, quantity = obj.Quantity });
            }

        }
        public int Delete(short id)
        {
            string sql = " DELETE FROM Budget WHERE Id = @Id";
            using (IDbConnection con = new SqlConnection(connectionString)) {
                return con.Execute(sql, new { Id = id });
            }
        }
        public int Update(BudgetModel obj) {
            string sql = "UPDATE  Budget SET Name = @name ,Description = @description ,Price = @price ,Quantity = @quantity Where Id =@id";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute(sql, obj );
            }
        
        }

    }
}
