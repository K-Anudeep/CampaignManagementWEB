using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Validations;
using MarketingManagement.API.Services;

namespace MarketingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AccessCheck _accessCheck;
        public UsersController(MarketingMgmtDBContext context)
        {
            _accessCheck = new AccessCheck(context);
        }

        //POST: api/Users/Login
        [HttpPost]
        [Route("Login")]
        public IActionResult UserValidation(string loginId, string password)
        {
            // Validate a User with their given Credentials
            var validation = _accessCheck.Validation(loginId, password);
            if(validation != null)
            {
                //Check for Admin or Executive
                Users Check = _accessCheck.AdminCheck(loginId);
                if(Check.IsAdmin == 1)
                {
                    return Content("Admin");
                }
                else
                {
                    return Content("Executive");
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
