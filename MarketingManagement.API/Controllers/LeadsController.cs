using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Validations;
using MarketingManagement.API.Services;


namespace MarketingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        
        //Adding Leads
        [HttpPost]
        [Route("AddLeads")]
        public IActionResult AddLeads(object leads)
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetALead/{leadId}")]
        public IActionResult GetALead(int leadId)
        {
            return Ok();
        }
}
}


