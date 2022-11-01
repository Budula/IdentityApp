using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ProductDbContext DbContext;
        public AdminController(ProductDbContext dbContext) => DbContext = dbContext;

        public IActionResult Index() => View(DbContext.Products);

        [HttpGet]
        public IActionResult Create() => View("Edit", new Product());
        [HttpGet]
        public IActionResult Edit(long id)
        {
            Product product = DbContext.Find<Product>(id);
            if(product != null)
            {
                return View("Edit", product);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Save(Product product)
        {
            DbContext.Update(product);
            DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            Product product = DbContext.Find<Product>(id);
            if( product != null)
            {
                DbContext.Remove(product);
                DbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
