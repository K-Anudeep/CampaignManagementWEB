using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
