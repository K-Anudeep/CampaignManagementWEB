using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MarketingManagement.API.DataContext;
using System;

namespace MarketingManagement.API.Models.Repositories
{
    public class UserRepo : IUsersRepo
    {
        private readonly MarketingMgmtDBContext _context;

        public UserRepo(MarketingMgmtDBContext context)
        {
            _context = context;
        }

        public void AddUsers(Users user)
        {
            user.Discontinued = 0;
            _context.Add(user);
            _context.SaveChanges();
        }

        public bool DiscontinueUser(int uId)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserID == uId);
            if(user != null)
            {
                user.Discontinued = 1;
                _context.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Failed to Add User");
            }
        }

        public IEnumerable<Users> DisplayUsers()
        {
            //Gets List of All Users
            return _context.Users.ToList();
        }

        public Users OneUser(int uId)
        {
            //Gets User by uId
            return _context.Users.Find(uId);
        }
    }
}
