using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Secomez.Models;

namespace Secomez.Pages
{
    public class ProductUsersModel : PageModel
    {
        public readonly AppDataContext _db;
        public readonly Cart _cart;

        public List<Product> ProductList { get; set; }

        public ProductUsersModel(AppDataContext db, Cart cart)
        {
            _db = db;
            _cart = cart;
        }
        public void OnGet()
        {
            ProductList = _db.Products.ToList();
        }
		public IActionResult OnPostAddToCart(int productId)
		{
			var product = _db.Products.Find(productId);
			if (product != null)
			{
				var cartItem = new CartItem
				{
					ProductId = product.Id,
					Quantity = 1 // You might adjust this based on your requirements
				};

				_cart.AddItem(cartItem);
			}

			return RedirectToPage("/Cart"); // Redirect to the cart page
		}

		public IActionResult OnPostRemoveFromCart(int productId)
		{
			_cart.RemoveItem(productId);

			return RedirectToPage("/Cart"); // Redirect to the cart page
		}
	}

}
