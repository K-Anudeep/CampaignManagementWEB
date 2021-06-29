using Microsoft.AspNetCore.Mvc;

namespace MarketingManagement.WEBUI.Controllers
{
    public class StartpageController : Controller
    {
        public IActionResult UserLogin()
        {
            return View();
        }
    }
}