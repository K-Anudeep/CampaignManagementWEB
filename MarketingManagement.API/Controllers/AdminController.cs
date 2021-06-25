using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Services;
using MarketingManagement.API.Models.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace MarketingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MarketingMgmtDBContext _context;
        private readonly AdminServices _admin;
        private readonly AccessCheck accessCheck;

        public AdminController(MarketingMgmtDBContext context)
        {
            _context = context;
            _admin = new AdminServices(context);
            accessCheck = new AccessCheck(context);
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
        public ActionResult<Users> AddUsers([Bind("FullName, LoginID, Password, DateOfJoin, Address, IsAdmin")] Users user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (UsersExists(user.LoginID))
                    {
                        throw new Exception("Login ID already exists!");
                    }

                    //Send User details to Repo for insertion to DB
                    _admin.AddUser(user);
                    return CreatedAtAction("GetOneUser", new { userId = user.UserID }, user);
                }
                else
                {
                    throw new Exception("Model State is not valid");
                }
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
                //Check if Discontinued or not
                var isDiscontinued = _admin.DiscontinueUser(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
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
                return Content(ex.Message);
            }
        }

        // GET: api/Admin/Users/5
        [HttpGet("User/GetOneUser/{userId}")]
        public ActionResult<Users> GetOneUser(int userId)
        {
            //Calls User repo to get a specific user by Id
            var users = _admin.OneUser(userId);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        private bool UsersExists(string loginId)
        {
            return _context.Users.Any(e => e.LoginID == loginId);
        }
        private bool UsersIdExists(int userId)
        {
            return _context.Users.Any(e => e.UserID == userId);
        }

        //PRODUCTS

        //POST: api/Admin/Products/Add
        [Route("Products/Add")]
        [HttpPost]
        public ActionResult<Products> AddProducts([Bind("ProductName, Description, UnitPrice")] Products products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ProductNameExists(products.ProductName))
                    {
                        throw new Exception("A product with that name already exists!");
                    }

                    //Send User details to Repo for insertion to DB
                    if (_admin.AddProducts(products))
                        return CreatedAtAction("OneProduct", new { productId = products.ProductID}, products);
                    else
                        throw new Exception("Could not add Product");
                }
                else
                {
                    throw new Exception("Model State is not valid");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        //DELETE: api/Admin/Products/Delete/{productId}
        [Route("Products/Delete/{productId}")]
        [HttpDelete]
        public ActionResult<Products> DeleteProduct(int productId)
        {
            try
            {
                if(!ProductIdExists(productId))
                {
                    throw new Exception("Product does not exist!"); 
                }
                //Delete product with given Product ID
                _admin.DeleteProduct(productId);
                return Ok();
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        //GET: api/Admin/Products/GetAll
        [Route("Products/GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetAll()
        {
            try
            {
                var products = _admin.GetAllProducts();
                return Ok(products);
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
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
            catch(Exception ex)
            {
                return Content(ex.Message);
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
        public ActionResult<Campaigns> AddCampaign([Bind("Name, Venue, AssignedTo, StartedOn, CompletedOn")] Campaigns campaigns)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CampaignNameExists(campaigns.Name))
                    {
                        throw new Exception("A campaign with that name already exists!");
                    }
                    if(!UsersIdExists(campaigns.AssignedTo))
                    {
                        throw new Exception("User assigned to this Campaign does not exist!");
                    }

                    var isAdmin = accessCheck.AdminCheck(campaigns.AssignedTo);
                    //Check if user is Admin
                    if(isAdmin.IsAdmin == 1)
                    {
                        throw new Exception("Admins cannot be assinged to campaigns");
                    }

                    campaigns.CompletedOn = campaigns.StartedOn.AddDays(7);

                    //Send User details to Repo for insertion to DB
                    if (_admin.AddCampaign(campaigns))
                        return CreatedAtAction("OneCampaign", new { campaignId = campaigns.CampaignID }, campaigns);
                    else
                        throw new Exception("Could not add campaign");
                }
                else
                {
                    throw new Exception("Model State is not valid");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        //GET: api/Admin/Campaign/OneCampaign/{camapaignId}
        [Route("Campaign/OneCampaign/{campaignId}")]
        [HttpGet]
        public ActionResult<Campaigns> OneCampaign(int campaignId)
        {
            try
            {
                if (!CampaignIdExists(campaignId))
                {
                    throw new Exception("A campaign with that ID does not exist!");
                }

                var products = _admin.OneCampaign(campaignId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
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
                if (!CampaignIdExists(campaignId))
                {
                    throw new Exception("A campaign with that ID does not exist!");
                }

                var campaign = _context.Campaigns.Find(campaignId);
                campaign.IsOpen = false;
                //Update Campaign
                var isClosed = _admin.CloseCampagin(campaign);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
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
                if(!CampaignIdExists(campaignId))
                {
                    throw new Exception("Campaign ID provided does not exist!");
                }

                var leads = _admin.ViewLeadByCampaign(campaignId);
                return Ok(leads);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        //GET: api/Admin/Reports/CampaignByExecutive
        [Route("Reports/CampaignByExecutive")]
        [HttpGet]
        public ActionResult<IEnumerable<Campaigns>> CampaignByExecutive()
        {
            try
            {
                var campaigns = _admin.ViewCampaingByExecutive();
                return Ok(campaigns);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
