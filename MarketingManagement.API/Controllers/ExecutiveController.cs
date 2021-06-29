using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Validations;
using MarketingManagement.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketingManagement.API.Controllers
{
    [Authorize(Roles = "Executive")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutiveController : ControllerBase
    {
        private readonly MarketingMgmtDbContext _context;
        private readonly DataChecks _dataChecks;
        private readonly ExecutiveService _executive;

        public ExecutiveController(MarketingMgmtDbContext context)
        {
            _context = context;
            _executive = new ExecutiveService(context);
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

        // POST: api/Executive/Leads/Add
        [Route("Leads/Add")]
        [HttpPost]
        public ActionResult<Leads> CreateLeads(
            [Bind("CampaignID, ConsumerName, EmailAddress, PhoneNo, PreferredMoC, DateApproached, ProductID")]
            Leads leads)
        {
            try
            {
                //Checks if Campaign ID exists
                if (!_dataChecks.CheckCampaign(leads.CampaignID))
                    throw new Exception("Campaign ID given does not exist!");
                //Check if Camapaign is Open or Close
                if (!_dataChecks.CampaignStatusCheck(leads.CampaignID))
                    throw new Exception("Given Campaign is Closed! Cannot create new Lead.");
                //Checks if Product ID exists
                if (!_dataChecks.CheckProduct(leads.ProductID))
                    throw new Exception("Product ID given does not exist!");

                leads.Status = "New";

                _executive.AddLeads(leads);

                return CreatedAtAction("GetOneLead", new {id = leads.LeadID}, leads);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Executive/Leads/FollowLead
        [HttpPut("Leads/FollowLead/{leadId}/{leadStatus}")]
        public IActionResult FollowLead(int leadId, string leadStatus)
        {
            if (!LeadsExists(leadId)) throw new Exception("Given Lead ID does not exist!");

            try
            {
                var leads = _context.Leads.Find(leadId);
                leads.Status = leadStatus;
                _executive.FollowLead(leads);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            return Content($"Lead {leadId} Updated with {leadStatus}");
        }

        // GET: api/Executive/Leads/GetLeadsByMe
        [Route("Leads/GetLeadsByMe")]
        [HttpPost]
        public ActionResult<IEnumerable<Leads>> GetLeadsByMe(int userId)
        {
            //var currentUser = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            var leads = _executive.ViewLeads(userId);
            return Ok(leads);
        }

        //INTERNAL USE ONLY
        [Route("Leads/GetOneLead")]
        [HttpGet]
        public async Task<ActionResult<Leads>> GetOneLead(int id)
        {
            var leads = await _context.Leads.FindAsync(id);

            if (leads == null) return NotFound();

            return leads;
        }

        private bool LeadsExists(int id)
        {
            return _context.Leads.Any(e => e.LeadID == id);
        }

        //SALES
        // POST: api/Executive/Sales/Add
        [Route("Sales/Add")]
        [HttpPost]
        public ActionResult<Sales> CreateSales([Bind("LeadID, ShippingAddress, BillingAddress, CreatedON, PaymentMode")]
            Sales sales)
        {
            try
            {
                //Checks if Lead ID exists
                if (!LeadsExists(sales.LeadID))
                    throw new Exception("Lead ID given does not exist!");
                //Checks if Lead Status is Won
                if (!_dataChecks.CheckLeadStatus(sales.LeadID))
                    throw new Exception("Sale Orders can only be created for Leads that have 'Won'");

                _executive.AddSales(sales);

                return CreatedAtAction("GetOneSale", new {orderId = sales.OrderID}, sales);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Executive/Sales/GetSales
        [Route("Sales/GetSales")]
        [HttpGet]
        public ActionResult<IEnumerable<Leads>> GetSales()
        {
            //Get all sales
            var sales = _executive.ViewSales();
            return Ok(sales);
        }

        //INTERNAL USE ONLY
        [Route("Sales/GetOneSale")]
        [HttpGet]
        public async Task<ActionResult<Leads>> GetOneSale(int orderId)
        {
            var leads = await _context.Leads.FindAsync(orderId);

            if (leads == null) return NotFound();

            return leads;
        }

        //CAMPAIGNS

        //GET: api/Executive/Campaigns/AssignedToMe
        [Route("Campaigns/AssignedToMe")]
        [HttpPost]
        public ActionResult<IEnumerable<Campaigns>> GetCampaignAsgnToMe(Users user)
        {
            var currentUser = user.UserID;
            var campaigns = _executive.ViewCampaignsAssigned(currentUser);
            return Ok(campaigns);
        }
    }
}