using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers;

public abstract class BaseAdminController : BaseController
{
    private MyContext context = new MyContext(); //DUPLICATED?
    
    public void SetIsRole()
    {
        @ViewBag.IsAdmin = false;
        @ViewBag.IsDelaer = false;
        @ViewBag.IsUser = false;

        var UserId = HttpContext.Session.GetInt32("login");
        User user = context.Users.Where(x => x.Id == UserId).FirstOrDefault();
        @ViewBag.User = user;
		
        if (user == null)
            return;
        if (user.IdRole >= 0)
            @ViewBag.IsUser = true;
        if (user.IdRole >= 1)
            @ViewBag.IsDelaer = true;
        if (user.IdRole >= 2)
            @ViewBag.IsAdmin = true;
    }
}