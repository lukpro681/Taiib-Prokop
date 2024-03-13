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
    [Table("Orders")]
    public class Order : IEntityTypeConfiguration<Order>
    {
        [Key]
        public int Id { get; set; }
        
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
        
        public required DateTime date { get; set; }
        public IEnumerable<OrderPosition> OrderPositions { get; set; }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasMany(x => x.OrderPositions)
                .WithOne(x => x.Order)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
