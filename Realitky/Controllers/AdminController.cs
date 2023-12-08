using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Realitky.Controllers;

public class AdminController : Controller
{
    // public IActionResult Index()
    // {
    //     // return View();
    // }
	public IActionResult Offers()
	{
		return View();
	}
	public IActionResult Users()
	{
		return View();
	}
	public IActionResult Requests()
	{
		return View();
	}
	public IActionResult Parameters()
	{
		return View();
	}
	/*--------------------------------*/
	public IActionResult Login()
	{
		return View();
	}
}
