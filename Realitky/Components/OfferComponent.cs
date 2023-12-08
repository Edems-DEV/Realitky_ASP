using Microsoft.AspNetCore.Mvc;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers;

public class OfferComponent : ViewComponent
{
    public IViewComponentResult Invoke(Offer offer)
    {
        this.ViewBag.Offer = offer;
        
        return View();
    }
}
