using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Services
{
    public interface IAdminServices
    {
        //PRODUCTS
        bool AddProducts(Products products);

        List<Products> ViewProducts();

        Products OneProduct(int productId);

        bool DeleteProduct(int productId);

        //CAMPAIGN

        bool AddCampaign(Campaigns campaigns);

        bool CloseCampagin(int campaignId);

        Campaigns OneCampaign(int campaignId);

        //USERS

        bool AddUser(Users users);

        IEnumerable<Users> DisplayUsers();

        bool DiscontinueUser(int userId);

        Users OneUser(int userId);

        //Reports

        List<Leads> ViewLeadByCampaign(int campaignId);

        List<Campaigns> ViewCampaingByExecutive(int executiveId);

    }
}
