using InvalidOperationException = System.InvalidOperationException;

namespace WebApp.Models
{
    public class CategoryRepository
    {
        private readonly string connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Store") ?? throw new InvalidOperationException("Store database not found");
        }

    }
}
