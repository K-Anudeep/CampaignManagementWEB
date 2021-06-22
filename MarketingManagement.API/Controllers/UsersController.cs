using Microsoft.AspNetCore.Mvc;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Validations;
using Microsoft.AspNetCore.Http;

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
                Users Check = _accessCheck.AdminCheck(validation.UserID);
                if(Check.IsAdmin == 1)
                {
                    HttpContext.Session.SetInt32("UserId", validation.UserID);
                    HttpContext.Session.SetInt32("IsAdmin", validation.IsAdmin);
                    return Content("Admin");
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", validation.UserID);
                    HttpContext.Session.SetInt32("IsAdmin", validation.IsAdmin);
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
