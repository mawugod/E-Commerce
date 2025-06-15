using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Secomez.Models;
using System.Collections.Generic;
using System.Linq;

namespace Secomez.Pages
{
    public class AddToCartModel : PageModel
    {
        public readonly AppDataContext _db;

        public AddToCartModel(AppDataContext db)
        {
            _db = db;
        }

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public SelectList ProductList { get; set; }

        public void OnGet()
        {
            var products = _db.Products.ToList();
            ProductList = new SelectList(products, nameof(Product.Id), nameof(Product.Name));
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add the product to the cart here
            // For example, you can create a new CartItem object and add it to the user's cart
            // You may need to create a new model called CartItem to store the product and quantity

            return RedirectToPage("./Products");
        }
    }
}