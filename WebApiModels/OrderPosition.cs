using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiModels
{
    public class OrderPosition : IEntityTypeConfiguration<OrderPosition>
    {
        [Key]
        public int Id { get; set; }

        public int OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public required Order Order { get; set; }
        public required int Amount { get; set; }
        public required double Price { get; set; }

        public required IEnumerable<Product> products { get; set; }

        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderPositions)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(x => x.products)
                .WithOne(x => x.orderPosition)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
