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
        offersQuery = offersQuery.Take(show);
        
        int? UserId = HttpContext.Session.GetInt32("login");
        if (UserId != null)
        {
            int id = (int)UserId;
            offersQuery = MapLikesToffers(id, offersQuery);
        }
        
        this.ViewBag.Offers = offersQuery.ToList();
        @ViewBag.UserId = UserId;

        
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
        @ViewBag.Dealers = this.context.Users.Where(u => u.IdRole == 1).ToList();
        
        return View();
    }
    
    public IActionResult Chats()
    {
        int? userId = HttpContext.Session.GetInt32("login");
        List<Request_user> threads = this.context.Request_user.Where(t => t.IdUser == userId).ToList();
        foreach (var thread in threads)
        {
            //thread.IncludeMessages(this.context); //not needed
            thread.IncludeOffer(this.context);
        }
        @ViewBag.Threads = threads;
        
        return View();
    }
    /*--------------------------------*/
    public IActionResult Detail(int id)
    {
        Offer offer = this.context.Offers.Find(id);
            offer.IncludeParametrs(this.context);
            offer.IncludeGallery(this.context);
            offer.IncludeDealer(this.context);
        
        this.ViewBag.Offer = offer;
        
        @ViewBag.UserId = HttpContext.Session.GetInt32("login");
        
        return View();
    }
    public IActionResult ChatDetail(int id)
    {
        Request_user thread = this.context.Request_user.Find(id);
            thread.IncludeMessages(this.context);
            thread.IncludeOffer(this.context);

        int? UserId = HttpContext.Session.GetInt32("login");
        if (UserId == null)
            UserId = 14; //DEBUG (anonym)
        User curent_user = this.context.Users.Find(UserId);
        
        @ViewBag.Thread = thread;
        @ViewBag.User = curent_user;

        if (curent_user == null)
            return RedirectToAction("Index", "Login");
        if (thread == null)
            return RedirectToAction("Chats", "Root");
        return View();
    }
    [HttpPost]
    public IActionResult Detail2(Request request)
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
    [HttpPost]
    public IActionResult Detail(Request_user request)
    {
        Request_user db = new Request_user();
        db.IdUser = request.IdUser;
        db.IdOffer = request.IdOffer;
        this.context.Request_user.Add(db);
        this.context.SaveChanges(); //generate id
        
        Request_user db2 = this.context.Request_user
                            .Where(x => 
                                   request.IdUser == x.IdUser &&
                                   request.IdOffer == x.IdOffer)
                            .FirstOrDefault();
        Message msg = new Message();
        msg.IdThread = db2.Id;
        msg.IdSender = request.IdUser;
        msg.content  = request.Text;
        msg.sent_at = DateTime.Now;
        
        this.context.Message.Add(msg);
        this.context.SaveChanges();

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    //--------------------------------
    public IQueryable<Offer> MapLikesToffers(int currentUserId, IQueryable<Offer> offers)
    {
        foreach (var offer in offers)
        {
            offer.IncludeFavorite(new MyContext(), currentUserId); //roll back? (new connection for each offer?) [Commit]
        }

        return offers;
    }
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

        return RedirectToAction("Catalog"); // TODO: Redirect to the same original action
    }
}
