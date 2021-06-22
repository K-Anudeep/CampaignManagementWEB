using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories;

namespace MarketingManagement.API.Models.Validations
{
    public class AccessCheck
    {
        private readonly MarketingMgmtDBContext _context;

        public AccessCheck(MarketingMgmtDBContext context)
        {
            _context = context;
        }

        public Users Validation(string loginID, string password)
        {
            return _context.Users.Where(a => a.LoginID.Equals(loginID)
                                    && a.Password.Equals(password)).FirstOrDefault();
        }

        public Users AdminCheck(int userId)
        {
            return _context.Users.SingleOrDefault(s => s.UserID == userId);
        }
    }
}
