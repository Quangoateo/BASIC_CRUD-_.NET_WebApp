using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Budget")]
    public class BudgetModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string Description { get; set; } = null!;
            public double Price { get; set; }
            public int Quantity { get; set; }
    
    
    }
    
}
