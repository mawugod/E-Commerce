using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Secomez.Models;

namespace Secomez.Pages
{
    //[Authorize(Roles = "Admin")]
    public class ProductsModel : PageModel
    {
        public readonly AppDataContext _db;

        public List<Product> ProductList { get; set; }

        public ProductsModel(AppDataContext db)

        {
            _db = db;

        }

        public void OnGet()
        {

            {
                ProductList = _db.Products.ToList();

            }
        }
    }
}
