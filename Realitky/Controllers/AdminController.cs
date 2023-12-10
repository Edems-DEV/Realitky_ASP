using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers;

[Authorize]
public class AdminController : BaseController
{
	private MyContext context = new MyContext();

	public void SetIsRole()
	{
		@ViewBag.IsAdmin = false;
		@ViewBag.IsDelaer = false;
		@ViewBag.IsUser = false;

		var UserId = HttpContext.Session.GetInt32("login");
		User user = context.Users.Where(x => x.Id == UserId).FirstOrDefault();
		@ViewBag.User = user;
		
		if (user == null)
			return;
		if (user.IdRole >= 0)
			@ViewBag.IsUser = true;
		if (user.IdRole >= 1)
			@ViewBag.IsDelaer = true;
		if (user.IdRole >= 2)
			@ViewBag.IsAdmin = true;
	}
	
    public IActionResult Index()
    {
	    return RedirectToAction("Offers");
    }
	public IActionResult Offers()
	{
		SetIsRole();
		var UserId = HttpContext.Session.GetInt32("login");
		@ViewBag.MyOffers = context.Offers.Where(x => x.Id == UserId).ToList();
		if (@ViewBag.IsAdmin)
			@ViewBag.AllOffers = context.Offers.ToList();
		return View();
	}
	public IActionResult Users()
	{
		SetIsRole();
		return View();
	}
	public IActionResult Requests()
	{
		SetIsRole();
		return View();
	}
	public IActionResult Parameters()
	{
		SetIsRole();
		return View();
	}
	public IActionResult Profile()
	{
		SetIsRole();
		return View();
	}
}
