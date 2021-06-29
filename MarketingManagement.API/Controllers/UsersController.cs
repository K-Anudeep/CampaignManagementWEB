using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Helpers;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MarketingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AccessCheck _accessCheck;
        private readonly AppSettings _appSettings;
        Session session = null;

        public UsersController(MarketingMgmtDbContext context, IOptions<AppSettings> appSettings)
        {
            _accessCheck = new AccessCheck(context);
            _appSettings = appSettings.Value;
        }

        private string GenerateJwt(Users users)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            if (users.IsAdmin == 1)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new(ClaimTypes.Name, users.UserID.ToString()),
                        new(ClaimTypes.Role, "Admin")
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                users.Token = tokenHandler.WriteToken(token);
            }
            else
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new(ClaimTypes.Name, users.UserID.ToString()),
                        new(ClaimTypes.Role, "Executive")
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                users.Token = tokenHandler.WriteToken(token);
            }

            return users.Token;
        }

        //POST: api/Users/Login
        [HttpPost]
        [Route("Login")]
        public IActionResult UserValidation(Users users)
        {
            try
            {
                session = new Session();
                if (!ModelState.IsValid) throw new Exception("Check your Credentials and try again!");
                var loginId = users.LoginID;
                var password = users.Password;

                // Validate a User with their given Credentials
                var validation = _accessCheck.Validation(loginId, password);
                if (validation == null) return BadRequest("Empty or Wrong Credentials");
                //Check for Admin or Executive
                var check = _accessCheck.AdminCheck(validation.UserID);
                switch (check.IsAdmin)
                {
                    case 1:
                        var adminToken = GenerateJwt(validation);
                        HttpContext.Session.SetString("Token", adminToken);
                        session.UserSessionId = validation.UserID;
                        HttpContext.Session.SetString("FullName", validation.FullName);
                        HttpContext.Session.SetInt32("IsAdmin", validation.IsAdmin);
                        return Ok(validation);
                    case 0:
                        var execToken = GenerateJwt(validation);
                        HttpContext.Session.SetString("Token", execToken);
                        session.UserSessionId = validation.UserID;
                        HttpContext.Session.SetString("FullName", validation.FullName);
                        HttpContext.Session.SetInt32("IsAdmin", validation.IsAdmin);
                        return Ok(validation);
                    default:
                        return BadRequest("User Data error: Check your credentials or contact admin");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}