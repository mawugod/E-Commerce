using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Secomez.Models;

namespace Secomez.Pages
{
    public class CheckoutModel : PageModel
    {
        public readonly Cart _cart;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public CheckoutModel(Cart cart, IHttpContextAccessor httpContextAccessor)
        {
            _cart = cart;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnPostPlaceOrder(string customerName)
        {
            // Process the order, save it to the database, send confirmation email, etc.

            // For demonstration purposes, clear the cart after placing the order
            _cart.Items = new List<CartItem>();
            SaveCartToSession();

            // Redirect to a confirmation page or any other appropriate page
            return RedirectToPage("/Index");
        }

        private void SaveCartToSession()
        {
            var cartJson = JsonConvert.SerializeObject(_cart.Items);
            _httpContextAccessor.HttpContext.Session.SetString("Cart", cartJson);
        }
    
    }
}
