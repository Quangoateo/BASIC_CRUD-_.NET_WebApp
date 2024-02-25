using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace WebApp.Models
{
    public class TransRepository
    {
        private readonly string connectionString;
        public TransRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Store") ?? throw new InvalidOperationException("Store Database Not found");
        } 
    }
}
