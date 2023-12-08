using Microsoft.AspNetCore.Mvc;
using Realitky.Models;
using System.Diagnostics;
using WebApplication4.Models;

namespace Realitky.Controllers;

public class HomeController : Controller
{
    private MyContext context = new MyContext();

    public IActionResult Index() //Home
    {
        return View();
    }
    public IActionResult Catalog()
    {
        this.ViewBag.Offers = this.context.Offers.ToList();
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    /*--------------------------------*/
    public IActionResult Detail()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
