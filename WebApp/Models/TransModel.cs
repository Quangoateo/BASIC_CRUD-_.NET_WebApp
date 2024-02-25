
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Models
{
    [Table("Transactions")]
    public class TransModel
    {
        public int Id { get; set; }
        public short Category_Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = null!;
    }
}
