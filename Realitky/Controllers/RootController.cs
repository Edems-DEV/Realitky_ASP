using Microsoft.AspNetCore.Mvc;
using Realitky.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers;

public class RootController : BaseController
{
    private MyContext context = new MyContext();
    
    // public IActionResult GetOffers(int offset, int limit)
    // {
    //     var offers = context.Offers.OrderBy(o => o.Id).Skip(offset).Take(limit).ToList();
    //     return Json(offers);
    // }

    public IActionResult Index(int type = 10) //Home //int offset = 0, int limit = 2
    {
        //Counters
        @ViewBag.CountByt = this.context.Offers.Where(o => o.IdType == 0).Count();
        @ViewBag.CountDum = this.context.Offers.Where(o => o.IdType == 1).Count();
        @ViewBag.CountChata = this.context.Offers.Where(o => o.IdType == 2).Count();
        @ViewBag.CountPozemek = this.context.Offers.Where(o => o.IdType == 3).Count();
        //Other
        
        var offersQuery = this.context.Offers.Where(o => o.IsVisible).AsQueryable();
        if (type != 10)
            offersQuery = offersQuery.Where(o => o.IdType == type);
        this.ViewBag.Offers = offersQuery.ToList();
        // @ViewBag.Offers = this.context.Offers.Skip(offset).Take(limit).ToList();
        // @ViewBag.Offset = offset;
        // @ViewBag.Limit = limit;

        
        return View();
    }
    public IActionResult Catalog(int type = 10, int region = 0, int minP = 0, int maxP = 0, int minS = 0, int maxS = 0)
    {
        var offersQuery = this.context.Offers.Where(o => o.IsVisible).AsQueryable();

        // Apply filters only if they are not their default values
        if (type != 10)
            offersQuery = offersQuery.Where(o => o.IdType == type);
        if (region != 0)
            offersQuery = offersQuery.Where(o => o.IdRegion == region);
        if (minP != 0)
            offersQuery = offersQuery.Where(o => o.price >= minP);
        if (maxP != 0)
            offersQuery = offersQuery.Where(o => o.price <= maxP);
        if (minS != 0)
            offersQuery = offersQuery.Where(o => o.size >= minS);
        if (maxS != 0)
            offersQuery = offersQuery.Where(o => o.size <= maxS);
        
        //Load based on filters
        this.ViewBag.Offers = offersQuery.ToList();

        //Load data
        this.ViewBag.Regions = this.context.Region.ToList();
        this.ViewBag.Types = this.context.Type.ToList();
        
        //ViewBag
        @ViewBag.Type = type;
        @ViewBag.Region = region;
        @ViewBag.MinP = minP;
        @ViewBag.MaxP = maxP;
        @ViewBag.MinS = minS;
        @ViewBag.MaxS = maxS;
        
        return View();
    }
    public IActionResult Contact()
    {
        var offersQuery = this.context.Offers.Where(o => o.IsVisible).AsQueryable();
        @ViewBag.Dealers = this.context.Users.Where(u => u.IdRole == 1).ToList();
        
        return View();
    }
    /*--------------------------------*/
    public IActionResult Detail(int id)
    {
        Offer offer = context.Offers
            .Include(o => o.ParametrsOffers)
            .ThenInclude(po => po.Parametr)
            .Include(o => o.Gallery) // Include the Gallery entities
            .FirstOrDefault(o => o.Id == id);
        User dealer = this.context.Users.Find(offer.IdDealer);
        
        this.ViewBag.Offer = offer;
        this.ViewBag.Dealer = dealer;
        
        return View();
    }
    [HttpPost]
    public IActionResult Detail(Request request)
    {
        Request db = new Request();
        db.IdOffer = request.IdOffer;
        db.email = request.email;
        db.name = request.name;
        db.phone = request.phone;
        db.text = request.text;
        this.context.Request.Add(db);
        this.context.SaveChanges();

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
