using System.Collections;
using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Services
{
    public interface IAdminServices
    {
        //PRODUCTS
        bool AddProducts(Products products);

        IEnumerable<Products> GetAllProducts();

        Products OneProduct(int productId);

        void DeleteProduct(int productId);

        //CAMPAIGN

        bool AddCampaign(Campaigns campaigns);

        bool CloseCampaign(Campaigns campaigns);

        Campaigns OneCampaign(int campaignId);

        //USERS

        bool AddUser(Users users);

        IEnumerable<Users> DisplayUsers();

        bool DiscontinueUser(int userId);

        Users OneUser(int userId);

        //Reports

        IEnumerable<Leads> ViewLeadByCampaign(int campaignId);

        IEnumerable ViewCampaignByExecutive();

    }
}
