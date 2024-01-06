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
	    return RedirectToAction("Index", "Offers");
    }

	public IActionResult Requests()
	{
		SetIsRole();
		var UserId = HttpContext.Session.GetInt32("login");
		var aaa = context.Request.Where(x => x.Id == UserId).ToList(); //todo: fix it (takes ID 1 request, not dealer connected)
		aaa.ForEach(x => x.IncludeOffer(context));
		@ViewBag.MyRequests = aaa;
		if (@ViewBag.IsAdmin)
		{
			var bbb = context.Request.ToList();
			bbb.ForEach(x => x.IncludeOffer(context));
			@ViewBag.AllRequests = bbb;
		}
		
		List<Request_user> threads = this.context.Request_user.ToList(); //TODO: Optimize (takes all)
		threads.ForEach(x => x.IncludeOffer(context));
		@ViewBag.Threads = threads.Where(x => x.Offer.IdDealer == UserId).ToList(); //filter to users only
		threads.ForEach(x => x.IncludeUser(context));
		
		return View();
	}
	public IActionResult ThreadDelete(int id) //todo: secure it (own controller)
	{
		Request_user request = this.context.Request_user.Find(id);

		this.context.Request_user.Remove(request);
		this.context.SaveChanges();

		return RedirectToAction("Requests");
	} 
	public IActionResult RequestsDelete(int id) //todo: secure it (own controller)
	{
		Request request = this.context.Request.Find(id);

		this.context.Request.Remove(request);
		this.context.SaveChanges();

		return RedirectToAction("Requests");
	} 
	
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
