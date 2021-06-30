using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Validations;
using MarketingManagement.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketingManagement.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AccessCheck _accessCheck;
        private readonly AdminServices _admin;
        private readonly MarketingMgmtDbContext _context;
        private readonly DataChecks _dataChecks;
        private Session session;

        public AdminController(MarketingMgmtDbContext context)
        {
            _context = context;
            _admin = new AdminServices(context);
            _accessCheck = new AccessCheck(context);
            _dataChecks = new DataChecks(context);
        }

        //LOGOUT
        [Route("Logout")]
        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Content("Logged Out!");
        }

        //USERS

        //Add User
        //POST: api/Admin/User/Add
        [Route("User/Add")]
        [HttpPost]
        public ActionResult<Users> AddUsers([Bind("FullName, LoginID, Password, DateOfJoin, Address, IsAdmin")]
            Users user)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Model State is not valid");
                if (UsersExists(user.LoginID)) throw new Exception("Login ID already exists!");

                //Send User details to Repo for insertion to DB
                _admin.AddUser(user);
                return CreatedAtAction("GetOneUser", new {userId = user.UserID}, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Discontinue User
        // PUT: api/Admin/User/Update/{id}
        [Route("User/DiscontinueUser/{userId}")]
        [HttpPut]
        public ActionResult<Users> DiscontinueUser(int userId)
        {
            try
            {
                //DISCONTINUE USER
                _admin.DiscontinueUser(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Admin/User/GetAll
        [Route("User/GetAll")]
        [HttpPost]
        public ActionResult<IEnumerable<Users>> GetAllUsers()
        {
            try
            {
                var users = _admin.DisplayUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Admin/Users/5
        [HttpGet("User/GetOneUser/{userId}")]
        public ActionResult<Users> GetOneUser(int userId)
        {
            //Calls User repo to get a specific user by Id
            var users = _admin.OneUser(userId);

            if (users == null) return NotFound();

            return Ok(users);
        }

        //INTERNAL ONLY

        //Check if User Login ID Exitsts
        private bool UsersExists(string loginId)
        {
            return _context.Users.Any(e => e.LoginID == loginId);
        }
        //Check to see if User ID exists
        private bool UsersIdExists(int userId)
        {
            return _context.Users.Any(e => e.UserID == userId);
        }

        //PRODUCTS

        //POST: api/Admin/Products/Add
        [Route("Products/Add")]
        [HttpPost]
        public ActionResult<Products> AddProducts([Bind("ProductName, Description, UnitPrice")]
            Products products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ProductNameExists(products.ProductName))
                        throw new Exception("A product with that name already exists!");

                    //Send User details to Repo for insertion to DB
                    if (_admin.AddProducts(products))
                        return CreatedAtAction("OneProduct", new {productId = products.ProductID}, products);
                    throw new Exception("Could not add Product");
                }

                throw new Exception("Model State is not valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE: api/Admin/Products/Delete/{productId}
        [Route("Products/Delete/{productId}")]
        [HttpDelete]
        public ActionResult<Products> DeleteProduct(int productId)
        {
            try
            {
                //Check for Product ID
                if (!ProductIdExists(productId)) throw new Exception("Product does not exist!");
                //Delete product with given Product ID
                _admin.DeleteProduct(productId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/Admin/Products/GetAll
        [Route("Products/GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetAll()
        {
            try
            {
                //GET and RETURN products
                var products = _admin.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/Admin/Products/OneProduct/{productId}
        [Route("Products/OneProduct/{productId}")]
        [HttpGet]
        public ActionResult<Products> OneProduct(int productId)
        {
            try
            {
                var products = _admin.OneProduct(productId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool ProductNameExists(string productName)
        {
            return _context.Products.Any(e => e.ProductName == productName);
        }

        private bool ProductIdExists(int productId)
        {
            return _context.Products.Any(e => e.ProductID == productId);
        }

        //CAMPAIGNS

        //POST: api/Admin/Campaign/Add
        [Route("Campaign/Add")]
        [HttpPost]
        public ActionResult<Campaigns> AddCampaign([Bind("Name, Venue, AssignedTo, StartedOn, CompletedOn")]
            Campaigns campaigns)
        {
            try
            {
                //Check for Model State
                if (!ModelState.IsValid) throw new Exception("Model State is not valid");
                //Check for Campaign Name
                if (CampaignNameExists(campaigns.Name))
                    throw new Exception("A campaign with that name already exists!");
                //Check for USER assigned to Campaign
                if (!UsersIdExists(campaigns.AssignedTo))
                    throw new Exception("User assigned to this Campaign does not exist!");

                var isAdmin = _accessCheck.AdminCheck(campaigns.AssignedTo);
                //Check if user is Admin
                if (isAdmin.IsAdmin == 1) throw new Exception("Admins cannot be assigned to campaigns");

                campaigns.CompletedOn = campaigns.StartedOn.AddDays(7);

                //Send User details to Repo for insertion to DB
                if (_admin.AddCampaign(campaigns))
                    return CreatedAtAction("OneCampaign", new {campaignId = campaigns.CampaignID}, campaigns);
                throw new Exception("Could not add campaign");
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return BadRequest(message);
            }
        }

        //GET: api/Admin/Campaign/OneCampaign/{campaignId}
        [Route("Campaign/OneCampaign/{campaignId}")]
        [HttpGet]
        public ActionResult<Campaigns> OneCampaign(int campaignId)
        {
            try
            {
                //Check for Campaign ID
                if (!CampaignIdExists(campaignId))
                    throw new Exception("A campaign with that ID does not exist!");
                var products = _admin.OneCampaign(campaignId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Close Campaign
        // PUT: api/Admin/Campaign/Close/{id}
        [Route("Campaign/Close/{campaignId}")]
        [HttpPut]
        public ActionResult<Campaigns> CloseCampaign(int campaignId)
        {
            try
            {
                //CHECK FOR CAMPAIGN ID
                if (!CampaignIdExists(campaignId)) throw new Exception("A campaign with that ID does not exist!");

                var campaign = _context.Campaigns.Find(campaignId);
                campaign.IsOpen = false;
                //Update Campaign
                _admin.CloseCampaign(campaign);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool CampaignNameExists(string campaignName)
        {
            return _context.Campaigns.Any(e => e.Name == campaignName);
        }

        private bool CampaignIdExists(int campaignId)
        {
            return _context.Campaigns.Any(e => e.CampaignID == campaignId);
        }

        //REPORTS

        //GET: api/Admin/Reports/LeadsByCampaign/{id}
        [Route("Reports/LeadsByCampaign/{campaignId}")]
        [HttpGet]
        public ActionResult<IEnumerable<Leads>> LeadsByCampaign(int campaignId)
        {
            try
            {
                //Check for Campaign
                if (!CampaignIdExists(campaignId)) throw new Exception("Campaign ID provided does not exist!");
                //Check if Lead exists
                if (!isLeadExists(campaignId))
                    throw new Exception("Leads for the given campaign do not exist");
                var leads = _admin.ViewLeadByCampaign(campaignId);
                if (leads == null) throw new Exception("No results found!");
                return Ok(leads);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Check for Leads
        //INTERNAL
        private bool isLeadExists(int campaignId)
        {
            return _context.Leads.Any(e => e.CampaignID == campaignId);
        }

        //GET: api/Admin/Reports/CampaignByExecutive
        [Route("Reports/CampaignByExecutive")]
        [HttpGet]
        public ActionResult<IEnumerable> CampaignByExecutive()
        {
            try
            {
                var campaigns = _admin.ViewCampaignByExecutive();
                return Ok(campaigns);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}