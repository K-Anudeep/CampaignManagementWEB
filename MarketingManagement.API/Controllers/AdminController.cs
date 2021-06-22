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
    public class AdminController : ControllerBase
    {
        private readonly MarketingMgmtDBContext _context;
        private readonly AdminServices _admin;
        public AdminController(MarketingMgmtDBContext context)
        {
            _context = context;
            _admin = new AdminServices(context);
        }

        //POST: api/Admin/Add
        [Route("Add")]
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
                    return Ok();
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

        //Discontinue User
        // PUT: api/Admin/Update/{id}
        [Route("DiscontinueUser/{userId}")]
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

        // GET: api/Admin/GetAll
        [Route("GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            return _admin.DisplayUsers().ToList();
        }

        // GET: api/Users/5
        [HttpGet("GetOneUser/{userId}")]
        public ActionResult<Users> GetUsers(int userId)
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
    }
}
