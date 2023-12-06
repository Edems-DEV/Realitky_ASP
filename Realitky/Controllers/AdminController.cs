using Microsoft.AspNetCore.Mvc;

namespace Realitky.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
