using System;

using Microsoft.AspNetCore.Mvc;

public class CustomerController : Controller
{
    private DataContext _dataContext;
    public CustomerController(DataContext db) => _dataContext = db;

    public IActionResult Index() => View(_dataContext.Customers.OrderBy(c => c.CompanyName));

    public ActionResult Register() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(Customer model)
    {
        _dataContext.AddCustomer(model);
        return RedirectToAction("Index");
    }
}

