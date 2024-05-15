using System.ComponentModel.DataAnnotations;

namespace WebApiModels
{
    public class User
    {
       public enum Level
        {
            Admin,
            Casual
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        public Level Type { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BasketPosition>? basketPositions { get; set; }
        public IEnumerable<Order>? orders { get;}
    }
}
