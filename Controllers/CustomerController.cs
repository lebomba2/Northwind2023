using Microsoft.AspNetCore.Mvc;
using System;

public class CustomerController : Controller
{
    private DataContext _dataContext;
    public CustomerController(DataContext db) => _dataContext = db;

    public IActionResult Index() => View(_dataContext.Customers.OrderBy(c => c.CompanyName));

    public IActionResult Register()
    {
        var model = new Customer();
        return View(model);
    }

    // http post version of Register
    // validation occurs here
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(Customer model)
    {
        if (!ModelState.IsValid) return View();
        if (_dataContext.Customers.Any(C => C.CompanyName == model.CompanyName))
        {
            ModelState.AddModelError("", "Name Must Be Unique");

        }
        else
        {
            _dataContext.Add(model);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
}