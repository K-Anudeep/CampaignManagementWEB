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
            return View(@"~/Views/AdminHome/Users/AddUsers.cshtml");
        }

        //View All, One User or Discontinue User
        public IActionResult AllUsers()
        {
            return View(@"~/Views/AdminHome/Users/AllUsers.cshtml");
        }

        public IActionResult OneUser()
        {
            return View(@"~/Views/AdminHome/Users/OneUser.cshtml");
        }

        //CAMPAIGNS

        public IActionResult AddCampaigns()
        {
            return View(@"~/Views/AdminHome/Campaigns/AddCampaigns.cshtml");
        }
        public IActionResult OneCampaign ()
        {
            return View(@"~/Views/AdminHome/Campaigns/OneCampaign.cshtml");
        }

        public IActionResult CampaignDetails()
        {
            return View(@"~/Views/AdminHome/Campaigns/CampaignDetails.cshtml");
        }
        
        //PRODUCTS
        
        public IActionResult AddProduct()
        {
            return View(@"~/Views/AdminHome/Products/AddProduct.cshtml");
        }
        public IActionResult AllProducts()
        {
            return View(@"~/Views/AdminHome/Products/AllProducts.cshtml");
        }
        public IActionResult OneProduct()
        {
            return View(@"~/Views/AdminHome/Products/OneProduct.cshtml");
        }
        
        //REPORTS
        public IActionResult ViewLeadsByCampaign()
        {
            return View(@"~/Views/AdminHome/Reports/ViewLeadsByCampaign.cshtml");
        }
        public IActionResult ViewCampaignsByExecutive()
        {
            return View(@"~/Views/AdminHome/Reports/ViewCampaignsByExecutive.cshtml");
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
