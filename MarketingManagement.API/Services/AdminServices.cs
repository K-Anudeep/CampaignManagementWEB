using System;
using System.Collections.Generic;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories;

namespace MarketingManagement.API.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly ProductRepo _productRepo;
        private readonly CampaignsRepo _campaignRepo;
        private readonly UserRepo userRepo;

        public AdminServices(MarketingMgmtDBContext context)
        {
            userRepo = new UserRepo(context);
            _productRepo = new ProductRepo();
            _campaignRepo = new CampaignsRepo();
        }

        //USERS
        public bool AddUser(Users users)
        {
                userRepo.AddUsers(users);
                return true;
        }

        public bool DiscontinueUser(int userId)
        {
            userRepo.DiscontinueUser(userId);
            return true;
        }

        public Users OneUser(int userId)
        {
            return userRepo.OneUser(userId);
        }

        public IEnumerable<Users> DisplayUsers()
        {
            return userRepo.DisplayUsers();
        }

        //CAMPAIGNS
        public bool AddCampaign(Campaigns campaigns)
        {
            throw new NotImplementedException();
        }

        public Campaigns OneCampaign(int campaignId)
        {
            throw new NotImplementedException();
        }

        public bool CloseCampagin(int campaignId)
        {
            throw new NotImplementedException();
        }

        //PRODUCTS
        public bool AddProducts(Products products)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Products> ViewProducts()
        {
            throw new NotImplementedException();
        }

        public Products OneProduct(int productId)
        {
            throw new NotImplementedException();
        }

        //REPORTS
        public List<Leads> ViewLeadByCampaign(int campaignId)
        {
            throw new NotImplementedException();
        }

        public List<Campaigns> ViewCampaingByExecutive(int executiveId)
        {
            throw new NotImplementedException();
        }
    }
}
