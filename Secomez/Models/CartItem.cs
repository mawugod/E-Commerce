namespace Secomez.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        
        public int Quantity { get; set; }

        // Foreign key for the Product
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        // Navigation property for the Product
        public Product Product { get; set; }

        // Navigation property for the Cart
        public Cart Cart { get; set; }
    }
}
