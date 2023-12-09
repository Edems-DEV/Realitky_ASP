using Microsoft.AspNetCore.Mvc;
using Realitky.Models;

namespace Realitky.Controllers;

public class LoginController : BaseController
{
    [HttpGet]
    public IActionResult Index(string c, string a)
    {
        this.ViewBag.Controller = c;
        this.ViewBag.Action = a;

        return View(new LoginModel());
    }

    [HttpPost]
    public IActionResult Index(LoginModel model, string c, string a)
    {
        if (model.Username == "admin" && BCrypt.Net.BCrypt.Verify(model.Password, "$2a$12$GyaUWUGRe8f/L3dlXqDL7.ub5yGBRSc/eEcZqn/V5fuWrsGyxkuaO"))
        {
            this.HttpContext.Session.SetString("login", model.Username);
            return RedirectToAction(a ?? "Index", c ?? "Home");
        }

        return View(model);
    }

    public IActionResult Logout()
    {
        this.HttpContext.Session.Remove("login");
        return RedirectToAction("Index");
    }
}