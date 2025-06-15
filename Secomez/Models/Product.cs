namespace Secomez.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public string Category { get; set; }

        // Navigation property for the CartItems
        public ICollection<CartItem> CartItems { get; set; }


    }
}
