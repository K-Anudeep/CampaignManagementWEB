using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface IUsersRepo
    {
        void AddUsers(Users user);

        IEnumerable<Users> DisplayUsers();

        Users OneUser(int uId);

        bool DiscontinueUser(int uId);
    }
}
