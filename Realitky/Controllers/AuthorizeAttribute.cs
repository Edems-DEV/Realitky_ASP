using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Realitky.Controllers;

public class AuthorizeAttribute : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        //ViewData["page"] = "Admin"; //

        //Controller controller = (Controller)context.Controller;

        //if (controller.HttpContext.Session.GetString("login") == null)
        //{
        //    string c = controller.Request.RouteValues["controller"].ToString();
        //    string a = controller.Request.RouteValues["action"].ToString();

        //    context.Result = new RedirectToActionResult("Index", "Login", new { c, a });
        //}
    }
}
