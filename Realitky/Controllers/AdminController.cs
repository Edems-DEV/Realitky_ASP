using Microsoft.AspNetCore.Mvc;

namespace Realitky.Controllers;

[Authorize]
public class AdminController : BaseController
{
    public IActionResult Index()
    {
	    return RedirectToAction("Offers");
    }
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
}
