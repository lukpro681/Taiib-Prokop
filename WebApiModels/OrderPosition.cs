using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiModels
{
    public class OrderPosition
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int Amount { get; set; }
        [Precision(10,2)]
        public decimal Price { get; set; }
        [ForeignKey(nameof(OrderID)),Required]
        public Order Order { get; set; }
        public int ProductID { get; set; }
        [Required,ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
    }
}
