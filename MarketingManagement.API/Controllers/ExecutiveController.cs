using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Services;
using MarketingManagement.API.Models.Validations;

namespace MarketingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutiveController : ControllerBase
    {
        private readonly MarketingMgmtDBContext _context;
        private readonly ExecutiveService _executive;
        private readonly DataChecks _dataChecks;
        public ExecutiveController(MarketingMgmtDBContext context)
        {
            _context = context;
            _executive = new ExecutiveService(context);
            _dataChecks = new DataChecks(context);
        }

        // POST: api/Executive/Leads/Add
        [Route("Leads/Add")]
        [HttpPost]
        public ActionResult<Leads> CreateLeads([Bind("CampaignID, ConsumerName, EmailAddress, PhoneNo, PreferredMoC, DateApproached, ProductID")] Leads leads)
        {
            try
            {
                //Checks if Campaign ID exists
                if (!_dataChecks.CheckCampaign(leads.CampaignID))
                    throw new Exception("Campaign ID given does not exist!");
                //Checks if Product ID exists
                if (!_dataChecks.CheckProduct(leads.ProductID))
                    throw new Exception("Product ID given does not exist!");

                leads.Status = "New";

                _executive.AddLeads(leads);

                return CreatedAtAction("GetLeads", new { id = leads.LeadID }, leads);
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // PUT: api/Executive/Leads/FollowLead
        [HttpPut("Leads/FollowLead/{leadId}/{leadStatus}")]
        public IActionResult FollowLead(int leadId, string leadStatus)
        {
            if (!LeadsExists(leadId))
            {
                throw new Exception("Given Lead ID does not exist!");
            }

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

        // GET: api/Executive
        [Route("Leads/GetLeadsByMe")]
        [HttpGet]
        public ActionResult<IEnumerable<Leads>> GetLeadsByMe()
        {
            var currentUser = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            var leads = _executive.ViewLeads(currentUser);
            return Ok(leads);
        }

        //INTERNAL USE ONLY
        [HttpGet]
        public async Task<ActionResult<Leads>> GetLeads(int id)
        {
            var leads = await _context.Leads.FindAsync(id);

            if (leads == null)
            {
                return NotFound();
            }

            return leads;
        }

        private bool LeadsExists(int id)
        {
            return _context.Leads.Any(e => e.LeadID == id);
        }
    }
}
