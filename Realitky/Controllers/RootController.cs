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
    
    public IQueryable<Offer> MapLikesToffers(int currentUserId, IQueryable<Offer> offers)
    {
        // Get a list of offer IDs marked as favorites by the current user
        var favoriteOfferIds = context.Favorite
            .Where(f => f.IdUser == currentUserId)
            .Select(f => f.IdOffer)
            .ToHashSet(); // Using HashSet for faster lookups

        // Set the IsFavorite property for each offer
        foreach (var offer in offers)
        {
            offer.IsFavorite = favoriteOfferIds.Contains(offer.Id);
        }

        return offers;
    }

    public IActionResult Index(int? type = null)
    {
        //Counters
        @ViewBag.CountByt = this.context.Offers.Where(o => o.IdType == 0).Count();
        @ViewBag.CountDum = this.context.Offers.Where(o => o.IdType == 1).Count();
        @ViewBag.CountChata = this.context.Offers.Where(o => o.IdType == 2).Count();
        @ViewBag.CountPozemek = this.context.Offers.Where(o => o.IdType == 3).Count();
        //Other
        
        var offersQuery = this.context.Offers.Where(o => o.IsVisible).AsQueryable();
        if (type != null)
            offersQuery = offersQuery.Where(o => o.IdType == type);
        int show = 6;
        this.ViewBag.Offers = offersQuery.Take(show).ToList();
        
        @ViewBag.UserId = HttpContext.Session.GetInt32("login");

        
        return View();
    }
    public IActionResult Catalog(int page = 0, bool? isRent = null, int? type = null, int? region = null, int? minP = null, int? maxP = null, int? minS = null, int? maxS = null)
    {
        var offersQuery = this.context.Offers.Where(o => o.IsVisible).AsQueryable();

        // Apply filters only if they are not their default values
        if (isRent != null)
            offersQuery = offersQuery.Where(o => o.IsRent == isRent);
        if (type != null)
            offersQuery = offersQuery.Where(o => o.IdType == type);
        if (region != null)
            offersQuery = offersQuery.Where(o => o.IdRegion == region);
        if (minP != null)
            offersQuery = offersQuery.Where(o => o.price >= minP);
        if (maxP != null)
            offersQuery = offersQuery.Where(o => o.price <= maxP);
        if (minS != null)
            offersQuery = offersQuery.Where(o => o.size >= minS);
        if (maxS != null)
            offersQuery = offersQuery.Where(o => o.size <= maxS);
        
        // Apply pegination
        int limit = 6; //change to at least 6 to look good
        int page2;
        if (page == null || page < 1)
            page2 = 0;
        else
            page2 = page*limit;
        offersQuery = offersQuery.Skip(page2).Take(limit);
        
        //Map likes
        int? UserId = HttpContext.Session.GetInt32("login");
        if (UserId != null)
        {
            int id = (int)UserId;
            offersQuery = MapLikesToffers(id, offersQuery);
        }
        

        //Load data
        this.ViewBag.Regions = this.context.Region.ToList();
        this.ViewBag.Types = this.context.Type.ToList();
        
        //Load based on filters
        this.ViewBag.Offers = offersQuery.ToList();

        //ViewBag
        @ViewBag.IsRent = isRent;
        @ViewBag.Type = type;
        @ViewBag.Region = region;
        @ViewBag.MinP = minP;
        @ViewBag.MaxP = maxP;
        @ViewBag.MinS = minS;
        @ViewBag.MaxS = maxS;
        
        @ViewBag.page = page;
        @ViewBag.pages = (this.context.Offers.Count() / limit)+1;

        @ViewBag.UserId = UserId;
        
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
    
    //--------------------------------
    [HttpPost]
    public IActionResult Like(int idOffer, int idUser)
    {
        var a = this.context.Favorite.Where(f => f.IdOffer == idOffer && f.IdUser == idUser).FirstOrDefault();

        if (a == null)
        {
            Favorite db = new Favorite();
            db.IdOffer = idOffer;
            db.IdUser = idUser;
            this.context.Favorite.Add(db);
        }
        else
        {
            this.context.Favorite.Remove(a);
        }
        this.context.SaveChanges();

        return RedirectToAction("Catalog");
    }
}
