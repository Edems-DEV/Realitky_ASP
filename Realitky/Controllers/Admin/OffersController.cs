using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers.Admin;

[Authorize]
public class OffersController : BaseAdminController
{
    private MyContext context = new MyContext();

    private void SetViewbag()
    {
        SetIsRole();
        
        @ViewBag.Parametrs = context.Parametrs.ToList();
        @ViewBag.Types = context.Type.ToList();
        @ViewBag.Regions = context.Region.ToList();
        @ViewBag.Dealers = context.Users.ToList(); //dealers cant change or should transfer?
    }
    public IActionResult Index()
    {
        SetIsRole();
        var UserId = HttpContext.Session.GetInt32("login");
        @ViewBag.MyOffers = context.Offers.Where(x => x.IdDealer == UserId).ToList();
        if (@ViewBag.IsAdmin)
            @ViewBag.AllOffers = context.Offers.ToList();
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        SetViewbag();
        return View(new Offer());
    }

    [HttpPost]
    public IActionResult Create(Offer offer)
    {
        var UserId = HttpContext.Session.GetInt32("login");
        if (UserId != null)
            offer.IdDealer = UserId;
        this.context.Offers.Add(offer);
        this.context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        SetViewbag();
        Offer offer = this.context.Offers.Find(id);
            offer.IncludeParametrs(this.context);
            offer.IncludeGallery(this.context);
            offer.IncludeDealer(this.context);
        return View(offer);
    }

    [HttpPost]
    public IActionResult Edit(Offer offer)
    {
        Offer db = this.context.Offers.Find(offer.Id);

        //if (offer.title != null || offer.title != "" || offer.title != db.title)
        db.title = offer.title;
        db.price = offer.price;
        db.summary = offer.summary;
        db.body = offer.body;
        db.thumbnail = offer.thumbnail;
        db.address = offer.address;
        db.size = offer.size;
        
        db.IsVisible = offer.IsVisible;
        db.IsRent = offer.IsRent;
        
        // db.IdType = offer.IdType;
        // db.IdRegion = offer.IdRegion;
        // db.IdDealer = offer.IdDealer;
        //
        // db.Gallery = offer.Gallery;
        // db.ParametrsOffers = offer.ParametrsOffers;
        

        this.context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Offer offer = this.context.Offers.Find(id);

        this.context.Offers.Remove(offer);
        this.context.SaveChanges();

        return RedirectToAction("Index");
    }
}

