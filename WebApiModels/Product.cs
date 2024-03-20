using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiModels
{
    public class Product : IEntityTypeConfiguration<Product>
    {
        [Key]
        public int ID { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
        public string? Image { get; set; }
        public required bool isActive { get; set; }
        public IEnumerable<BasketPosition> basketPositions { get; set; }

        public required OrderPosition orderPosition { get; set; }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasMany(x => x.basketPositions)
                .WithOne(x => x.Product)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.orderPosition)
                .WithMany(x => x.products)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
