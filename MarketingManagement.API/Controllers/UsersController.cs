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
        public UsersController(MarketingMgmtDbContext context)
        {
            _accessCheck = new AccessCheck(context);
        }

        //POST: api/Users/Login
        [HttpPost]
        [Route("Login")]
        public IActionResult UserValidation(Users users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginId = users.LoginID;
                    var password = users.Password;

                    // Validate a User with their given Credentials
                    var validation = _accessCheck.Validation(loginId, password);
                    if (validation != null)
                    {
                        //Check for Admin or Executive
                        var check = _accessCheck.AdminCheck(validation.UserID);
                        switch (check.IsAdmin)
                        {
                            case 1:
                                HttpContext.Session.SetInt32("UserId", validation.UserID);
                                HttpContext.Session.SetString("FullName", validation.FullName);
                                HttpContext.Session.SetInt32("IsAdmin", validation.IsAdmin);
                                return Content("Admin");
                            case 0:
                                HttpContext.Session.SetInt32("UserId", validation.UserID);
                                HttpContext.Session.SetString("FullName", validation.FullName);
                                HttpContext.Session.SetInt32("IsAdmin", validation.IsAdmin);
                                return Content("Executive");
                            default:
                                return BadRequest("Empty or Wrong Credentials");
                        }
                    }
                    else
                    {
                        return BadRequest("Empty or Wrong Credentials");
                    }
                }
                else
                {
                    throw new System.Exception("Check your Credentials and try again!");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}