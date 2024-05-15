using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiModels
{
    public class BasketPosition
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; 
        }public int Amount { get; set; }
        [ForeignKey(nameof(UserID)),Required]
        public User User { get; set; }
        [ForeignKey(nameof(ProductID)),Required]
        public Product Product { get; set; }
    }
}