using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApiModels
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Precision(10, 2)]
        public decimal Price { get; set; }
        [MaxLength(1000)]
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BasketPosition>? BasketPositions { get; set; }
        public IEnumerable<OrderPosition>? OrderPositions { get; set; }
    }
}
