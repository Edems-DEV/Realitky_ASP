using Microsoft.AspNetCore.Mvc;
using Realitky.Models.Entity;

namespace Realitky.Controllers;

public class DealerComponent : ViewComponent
{
    public IViewComponentResult Invoke(User user)
    {
        this.ViewBag.Dealer = user;
        
        return View();
    }
}
