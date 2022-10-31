using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    public class AdminModel : PageModel
    {
        public ProductDbContext DbContext { get; set; }
        public AdminModel(ProductDbContext context) => DbContext = context;

        public IActionResult OnPost(long id)
        {
            Product product = DbContext.Find<Product>(id);
            if (product != null)
            {
                DbContext.Remove(product);
                DbContext.SaveChanges();
            }
            return Page();            
        }

    }
}
