using System;
using System.Collections.Generic;
using System.Linq;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;

namespace MarketingManagement.API.Models.Repositories
{
    public class UserRepo : IUsersRepo
    {
        private readonly MarketingMgmtDbContext _context;

        public UserRepo(MarketingMgmtDbContext context)
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
            if (user != null)
            {
                user.Discontinued = 1;
                _context.SaveChanges();
                return true;
            }

            throw new Exception("User does not exist");
        }

        public IEnumerable<Users> DisplayUsers()
        {
            //Gets List of All Users
            return _context.Users;
        }

        public Users OneUser(int uId)
        {
            //Gets User by uId
            return _context.Users.Find(uId);
        }
    }
}