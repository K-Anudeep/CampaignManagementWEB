using MarketingManagement.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace MarketingManagement.WEBUI.Controllers
{
    public class ExecutiveHomeController : Controller
    {
        private readonly ILogger<ExecutiveHomeController> _logger;

        public ExecutiveHomeController(ILogger<ExecutiveHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //Leads
        public IActionResult CreateLeads()
        {
            return View();
        }
        public IActionResult FollowLead()
        {
            return View();
        }
        public IActionResult GetLeadsByMe()
        {
            return View();
        }

        //Sales
        public IActionResult CreateSales()
        {
            return View();
        }
        public IActionResult ViewSales()
        {
            return View();
        }
        //Campaign
        public IActionResult GetCampaignAsgnToMe()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
