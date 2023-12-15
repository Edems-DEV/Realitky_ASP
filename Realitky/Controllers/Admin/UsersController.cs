using Microsoft.AspNetCore.Mvc;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers.Admin;

public class UsersController : BaseAdminController
{
    private MyContext context = new MyContext();
    public IActionResult Index()
    {
        SetIsRole();
        if (@ViewBag.IsAdmin) //replace with admin atribut
            @ViewBag.AllUsers = context.Users.ToList();
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        SetIsRole();
        @ViewBag.Roles = context.Roles.ToList();
        return View(new User());
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        this.context.Users.Add(user);
        this.context.SaveChanges();

        return RedirectToAction("Edit", new { id = user.Id });
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        SetIsRole();
        @ViewBag.Roles = context.Roles.ToList();
        return View(this.context.Users.Find(id));
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        User db = this.context.Users.Find(user.Id);

        if (user.username != null || user.username != "" || user.username == db.username)
            db.username = user.username;
        // db.password = user.password;
        if(user.name != null || user.name != "" || user.name == db.name)
            db.name = user.name;
        db.email = user.email;
        db.phone = user.phone;
        db.avatar = user.avatar;
        db.IdRole = user.IdRole; //only admin can change role

        this.context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        User user = this.context.Users.Find(id);

        this.context.Users.Remove(user);
        this.context.SaveChanges();

        return RedirectToAction("Index");
    }
}

