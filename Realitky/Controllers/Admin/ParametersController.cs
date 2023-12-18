using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers.Admin;

[Authorize]
public class ParametersController : BaseAdminController
{
    private MyContext context = new MyContext();
    private void SetViewbag()
    {
        SetIsRole();
        
        @ViewBag.Offers = context.Offers.ToList();
    }
    public IActionResult Index()
    {
        SetIsRole();
        if (@ViewBag.IsAdmin) //replace with admin atribut
            @ViewBag.AllParameters = context.Parametrs.ToList(); //link apperinces
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        SetViewbag();
        return View(new Parametrs());
    }

    [HttpPost]
    public IActionResult Create(Parametrs parametrs)
    {
        this.context.Parametrs.Add(parametrs);
        this.context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        SetViewbag();

        return View(context.Parametrs.Find(id));
    }

    [HttpPost]
    public IActionResult Edit(Parametrs parametrs)
    {
        Parametrs db = this.context.Parametrs.Find(parametrs.Id);

        if (parametrs.name != null || parametrs.name != "" || parametrs.name == db.name)
            db.name = parametrs.name;

        this.context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Parametrs parametrs = this.context.Parametrs.Find(id);

        this.context.Parametrs.Remove(parametrs);
        this.context.SaveChanges();

        return RedirectToAction("Index");
    }
}

