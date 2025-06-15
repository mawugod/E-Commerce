using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Secomez.Models;

namespace Secomez.Pages
{
    public class CartModel : PageModel
    {
        public readonly AppDataContext _context;
        public readonly Cart _cart;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public CartModel(AppDataContext context, Cart cart, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _cart = cart;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            LoadCartFromSession();

            foreach (var item in _cart.Items)
            {
                // Fetch product details for each item in the cart
                item.Product = _context.Products.Find(item.ProductId);
            }
        }

        public IActionResult OnPostUpdateQuantity(int productId, int newQuantity)
        {
            LoadCartFromSession();

            var cartItem = _cart.Items.FirstOrDefault(item => item.ProductId == productId);

            if (cartItem != null)
            {
                // Update the quantity in the cart
                cartItem.Quantity = newQuantity;
                SaveCartToSession();
            }

            return RedirectToPage("/Cart");
        }

        public IActionResult OnPostRemoveFromCart(int productId)
        {
            LoadCartFromSession();

            _cart.RemoveItem(productId);
            SaveCartToSession();

            return RedirectToPage("/Cart");
        }

        // Add these methods
        private void SaveCartToDatabase()
        {
             _context.CartItems.AddRange(_cart.Items);
            _context.SaveChanges();
        }

        private void LoadCartFromDatabase()
        {
             _cart.Items = _context.CartItems.ToList();
        }

        public IActionResult OnGetLogout()
        {
            SaveCartToDatabase();
            _httpContextAccessor.HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostLogin()
        {
            LoadCartFromDatabase();
            SaveCartToSession();
            return RedirectToPage("/Cart");
        }
        private void LoadCartFromSession()
        {
            var cartJson = _httpContextAccessor.HttpContext.Session.GetString("Cart");

            if (!string.IsNullOrEmpty(cartJson))
            {
                _cart.Items = JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
            }
        }

        private void SaveCartToSession()
        {
            var cartJson = JsonConvert.SerializeObject(_cart.Items);
            _httpContextAccessor.HttpContext.Session.SetString("Cart", cartJson);
        }
    }
}
