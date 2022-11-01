using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private ProductDbContext DbContext;
        public StoreController(ProductDbContext dbcontext) => DbContext = dbcontext;

        public IActionResult Index() => View(DbContext.Products);        
    }
}
