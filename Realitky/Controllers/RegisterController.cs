using Microsoft.AspNetCore.Mvc;
using Realitky.Models;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers;

public class RegisterController : BaseController
{
    private MyContext context = new MyContext();
    
    [HttpGet]
    public IActionResult Index(string c, string a)
    {
        this.ViewBag.Controller = c;
        this.ViewBag.Action = a;

        return View(new User());
    }

    [HttpPost]
    public IActionResult Index(User model, string? c, string? a)
    {
        bool duplicate = context.Users.Where(u => u.email == model.username || u.username == model.username).Any();
        if (!duplicate)
        {
            model.password = BCrypt.Net.BCrypt.HashPassword(model.password);
            model.IdRole = 0; // = user
            this.context.Users.Add(model);
            this.context.SaveChanges();
        }

        return View(model);
    }

    public IActionResult Logout()
    {
        this.HttpContext.Session.Remove("login");
        return RedirectToAction("Index");
    }
}