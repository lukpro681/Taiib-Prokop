namespace BLL
{
    public class ProductDTO
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}