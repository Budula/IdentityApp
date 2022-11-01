using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace IdentityApp.Pages
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        public ProductDbContext DbContext{ get; set; }
        public Product Product { get; set; }

        public EditModel(ProductDbContext dbcontext) => DbContext = dbcontext;

        public void OnGet(long id)
        {
            Product = DbContext.Find<Product>(id) ?? new Product();
        }

        public IActionResult OnPost([Bind(Prefix = "Product")] Product product)
        {
            DbContext.Update(product);
            DbContext.SaveChanges();
            return RedirectToPage("Admin");
        }
        
    }
}
