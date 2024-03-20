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
    public class BasketPosition : IEntityTypeConfiguration<BasketPosition>
    {
        [Key]
        public int Id { get; set; }

        public required int ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        public required Product Product { get; set; }
        public required int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public required User User { get; set; }
        public required int Amount { get; set; }

        public void Configure(EntityTypeBuilder<BasketPosition> builder)
        {
            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.basketPositions)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.BasketPositions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
