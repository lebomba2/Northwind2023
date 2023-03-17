using System;

// this class inherits from the controller class and assigns the view
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    // this controller depends on the NorthwindRepository
    private DataContext _dataContext;
    public HomeController(DataContext db) => _dataContext = db;

    // filters the data to make sure that the discouncts are still relavant and only shows the first 3 at a time 
    public ActionResult Index() => View(_dataContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now).Take(3));
}
