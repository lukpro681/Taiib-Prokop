using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace WebApiModels
{

    public enum Type
    {
        Admin,
        Casual
    }

    public class User : IEntityTypeConfiguration<User>
    {
        public int ID { get; set; }

        public required string Login { get; set; }
        public required string Password { get; set; }
        public required Type Type { get; set; }
        public required bool IsActive { get; set; }
        public IEnumerable<BasketPosition> BasketPositions { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(x => x.BasketPositions)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}