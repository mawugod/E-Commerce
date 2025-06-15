using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Secomez.Models;

using System.ComponentModel.DataAnnotations;

namespace Secomez.Pages
{
    [Authorize(Roles = "Admin")]
    public class addProductModel : PageModel
    {
        public readonly AppDataContext _db;

        public addProductModel (AppDataContext db)
        {
            _db = db;
        }
        [BindProperty]
        [Required]
        public Product product { get; set; }

        public IActionResult OnPost()
        {
              
                _db.Products.Add(product);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Product added successfully!";
                return RedirectToAction("Index");
            

           

        }
    }
}
