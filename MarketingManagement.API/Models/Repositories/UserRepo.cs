using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;
using System.Collections.Generic;

namespace MarketingManagement.API.Models.Repositories
{
    public class UserRepo : IUsersRepo
    {
        public bool AddUsers(Users user)
        {
            throw new System.NotImplementedException();
        }

        public bool DiscontinueUser(int uId)
        {
            throw new System.NotImplementedException();
        }

        public List<Users> DisplayUsers()
        {
            throw new System.NotImplementedException();
        }

        public Users OneUser(int uId)
        {
            throw new System.NotImplementedException();
        }
    }
}
