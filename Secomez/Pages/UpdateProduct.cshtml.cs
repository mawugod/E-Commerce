using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Secomez.Models;

using System.ComponentModel.DataAnnotations;

namespace Secomez.Pages
{
    [Authorize(Roles = "Admin")]
    public class UpdateProductModel : PageModel
    {
        private readonly AppDataContext _db;

        public UpdateProductModel(AppDataContext db)
        {
            _db = db;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        [Required]
        public string Name { get; set; }

        [BindProperty]
        [Required]
        public string Description { get; set; }

        [BindProperty]
        [Required]
        public decimal Price { get; set; }

        [BindProperty]
        [Required]
        public string ProductImage { get; set; }

        [BindProperty]
        [Required]
        public string Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            ProductImage = product.ProductImage;
            Category = product.Category;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var productToUpdate = await _db.Products.FindAsync(Id);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            productToUpdate.Name = Name;
            productToUpdate.Description = Description;
            productToUpdate.Price = Price;
            productToUpdate.ProductImage = ProductImage;
            productToUpdate.Category = Category;

            await _db.SaveChangesAsync();

            return RedirectToPage("/ProductUsers");
        }
    }
}
