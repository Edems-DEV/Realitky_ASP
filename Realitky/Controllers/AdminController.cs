using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers;

[Authorize]
public class AdminController : BaseAdminController
{
	private MyContext context = new MyContext();
    public IActionResult Index()
    {
	    // return RedirectToAction("Offers");
	    return RedirectToAction("Index", "Offers");
    }
	// public IActionResult Offers()
	// {
	// 	SetIsRole();
	// 	var UserId = HttpContext.Session.GetInt32("login");
	// 	@ViewBag.MyOffers = context.Offers.Where(x => x.Id == UserId).ToList();
	// 	if (@ViewBag.IsAdmin)
	// 		@ViewBag.AllOffers = context.Offers.ToList();
	// 	return View();
	// }
	// public IActionResult Users()
	// {
	// 	SetIsRole();
	// 	if (@ViewBag.IsAdmin) //replace with admin atribut
	// 		@ViewBag.AllUsers = context.Users.ToList();
	// 	return View();
	// }
	public IActionResult Requests()
	{
		SetIsRole();
		var UserId = HttpContext.Session.GetInt32("login");
		@ViewBag.MyRequests = context.Request.Where(x => x.Id == UserId).ToList(); //todo: fix it (takes ID 1 request, not dealer connected)
		if (@ViewBag.IsAdmin)
			@ViewBag.AllRequests = context.Request.ToList();
		return View();
	}
	public IActionResult RequestsDelete(int id) //todo: secure it (own controller)
	{
		Request request = this.context.Request.Find(id);

		this.context.Request.Remove(request);
		this.context.SaveChanges();

		return RedirectToAction("Requests");
	} 
	// public IActionResult Parameters()
	// {
	// 	SetIsRole();
	// 	if (@ViewBag.IsAdmin) //replace with admin atribut
	// 		@ViewBag.AllParameters = context.Parametrs.ToList(); //link apperinces
	// 	return View();
	// }
	public IActionResult Profile()
	{
		SetIsRole();
		var UserId = HttpContext.Session.GetInt32("login");
		@ViewBag.User = context.Users.Find(UserId);
		return View();
	}
	
	[HttpGet]
	public IActionResult ProfileEdit(int id)
	{
		SetIsRole();
		@ViewBag.Id = id;
		return View(this.context.Users.Find(id));
	}

	[HttpPost]
	public IActionResult ProfileEdit(User user)
	{
		User db = this.context.Users.Find(user.Id); //TODO: fix it (form will lost ID => cant update)

		db.username = user.username;
		db.name = user.name;
		db.email = user.email;
		db.phone = user.phone;
		db.avatar = user.avatar;

		this.context.SaveChanges();

		return RedirectToAction("Profile");
	}
}
