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

        // Product/Index view passing the Products table, filtered by CategoryId and Discontinued, ordered by ProductName
        public IActionResult Index(int id) => View(_dataContext.Products.Where(p => p.CategoryId == id && p.Discontinued == false).OrderBy(p => p.ProductName));

        // Product/Current Discounts View
        public IActionResult CurrentDiscounts() => View(_dataContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));
    }
}