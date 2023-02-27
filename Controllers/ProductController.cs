using Microsoft.AspNetCore.Mvc;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        // this controller depends on the Northwind Repository
        private DataContext _dataContext;
        public ProductController(DataContext db) => _dataContext = db;

        // Product/Category view
        public IActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName).ToList());
    }
}