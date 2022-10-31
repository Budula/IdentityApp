using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    public class StoreController : Controller
    {
        private ProductDbContext DbContext;
        public StoreController(ProductDbContext dbcontext) => DbContext = dbcontext;

        public IActionResult Index() => View(DbContext.Products);        
    }
}
