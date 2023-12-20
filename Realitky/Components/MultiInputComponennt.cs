using Microsoft.AspNetCore.Mvc;

namespace Realitky.Controllers;

public class MultiInputComponennt : ViewComponent
{
    public IViewComponentResult Invoke(string label, List<string> items)
    {
        this.ViewBag.Label = label;
        this.ViewBag.Items= items;
        
        return View();
    }
}
