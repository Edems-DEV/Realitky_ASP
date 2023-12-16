using Microsoft.AspNetCore.Mvc;
using Realitky.Models;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers;

public class LoginController : BaseController
{
    private MyContext context = new MyContext();
    
    [HttpGet]
    public IActionResult Index(string c, string a)
    {
        this.ViewBag.Controller = c;
        this.ViewBag.Action = a;

        return View(new LoginModel());
    }

    [HttpPost]
    public IActionResult Index(LoginModel model, string? c, string? a)
    {
        User user = context.Users.Where(u => u.email == model.Username || u.username == model.Username).FirstOrDefault();
        if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.password))
        {
            // switch (user.IdRole)
            // {
            //     case 0:
            //         this.HttpContext.Session.SetString("role", "user");
            //         break;
            //     case 1:
            //         this.HttpContext.Session.SetString("role", "dealer");
            //         break;
            //     case 2:
            //         this.HttpContext.Session.SetString("role", "admin");
            //         return RedirectToAction(a ?? "Index", c ?? "Admin");
            //         break;
            // }
            this.HttpContext.Session.SetInt32("login", user.Id); //single session => all properties (query in db) => more secured?

            if (user.IdRole >= 1)
                return RedirectToAction(a ?? "Index", c ?? "Admin");

            return RedirectToAction(a ?? "Index", c ?? "");
        }

        return View(model);
    }

    public IActionResult Logout()
    {
        this.HttpContext.Session.Remove("login");
        return RedirectToAction("Index");
    }
}