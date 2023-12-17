using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Controllers;

public class AuthorizeAttribute : Attribute, IActionFilter
{
    private MyContext db = new MyContext();
    public void OnActionExecuted(ActionExecutedContext context) { }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Controller controller = (Controller) context.Controller;
        int? userId = controller.HttpContext.Session.GetInt32("login");
        User user = db.Users.Where(x => x.Id == userId).FirstOrDefault();
        
        if (user == null || user.IdRole == 0)
        {
            string controllerN = controller.Request.RouteValues["controller"].ToString();
            string actionN = controller.Request.RouteValues["action"].ToString();
            if (actionN == null || controllerN == null)
            {
                controllerN = "Root";
                actionN = "Index";
            }
            
            context.Result = new RedirectToActionResult("Index", "Login", new { controllerN, actionN });
            // context.Result = new RedirectToActionResult(actionN, controllerN, null);
        }
    }
}