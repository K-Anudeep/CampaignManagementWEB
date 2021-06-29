using System.Linq;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Validations
{
    public class AccessCheck
    {
        private readonly MarketingMgmtDbContext _context;

        public AccessCheck(MarketingMgmtDbContext context)
        {
            _context = context;
        }

        public Users Validation(string loginId, string password)
        {
            return _context.Users.FirstOrDefault(a => a.LoginID.Equals(loginId)
                                                      && a.Password.Equals(password));
        }

        public Users AdminCheck(int userId)
        {
            return _context.Users.SingleOrDefault(s => s.UserID == userId);
        }
    }
}