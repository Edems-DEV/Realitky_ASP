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
        //Counters
        @ViewBag.CountByt = this.context.Offers.Where(o => o.IdType == 0).Count();
        @ViewBag.CountDum = this.context.Offers.Where(o => o.IdType == 1).Count();
        @ViewBag.CountChata = this.context.Offers.Where(o => o.IdType == 2).Count();
        @ViewBag.CountPozemek = this.context.Offers.Where(o => o.IdType == 3).Count();
        //Other
        @ViewBag.Offers = this.context.Offers.ToList();
        
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
