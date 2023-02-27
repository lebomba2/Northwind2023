using System;

// this class inherits from the controller class and assigns the view
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
         public ActionResult Index() => View();
    }
}