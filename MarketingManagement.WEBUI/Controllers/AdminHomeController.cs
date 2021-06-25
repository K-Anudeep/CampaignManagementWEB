using MarketingManagement.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace MarketingManagement.WEBUI.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly ILogger<AdminHomeController> _logger;

        public AdminHomeController(ILogger<AdminHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.GetString("FullName");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //USERS

        //Manage Users through here
        public IActionResult AddUsers()
        {
            return View();
        }

        //View All, One User or Discontinue User
        public IActionResult AllUsers()
        {
            return View();
        }

        public IActionResult OneUser()
        {
            return View();
        }

        //CAMPAIGNS

        public IActionResult AddCampaigns()
        {
            return View();
        }
        public IActionResult CloseCampaign(int campaignId)
        {
            return View();
        }
         
        public IActionResult OneCampaign (int campaignId)
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult DeleteProduct()
        {
            return View();
        }
        public IActionResult ViewProduct()
        {
            return View();
        }
        public IActionResult OneProduct()
        {
            return View();
        }
        public IActionResult ViewLeadsByCampaign()
        {
            return View();
        }
        public IActionResult ViewLeadsByExecutive()
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
