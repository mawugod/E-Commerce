namespace Secomez.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public List<CartItem> Items { get; set; } =new List<CartItem>();



        public void AddItem(CartItem item)
        {
            // Add logic to handle adding items to the cart
            Items.Add(item);
        }

        public void RemoveItem(int productId)
        {
            // Add logic to handle removing items from the cart based on productId
            var itemToRemove = Items.FirstOrDefault(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }
    }
}
