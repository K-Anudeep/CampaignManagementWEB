using System.Collections.Generic;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories;

namespace MarketingManagement.API.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly CampaignsRepo _campaignsRepo;
        private readonly LeadsRepo _leadsRepo;
        private readonly GenericRepo<Campaigns> genericCampaignRepo;
        private readonly GenericRepo<Products> genericProductRepo;
        private readonly GenericRepo<Users> genericUserRepo;
        private readonly UserRepo userRepo;

        public AdminServices(MarketingMgmtDbContext context)
        {
            //Users
            userRepo = new UserRepo(context);
            genericUserRepo = new GenericRepo<Users>(context);

            //Generic Repo for Products
            genericProductRepo = new GenericRepo<Products>(context);
            //Generic Repo for Campaigns
            genericCampaignRepo = new GenericRepo<Campaigns>(context);

            _leadsRepo = new LeadsRepo(context);
            //Direct Campaign Repo
            _campaignsRepo = new CampaignsRepo(context);
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
            return genericUserRepo.GetAllRecords();
        }

        //CAMPAIGNS
        public bool AddCampaign(Campaigns campaigns)
        {
            campaigns.IsOpen = true;
            genericCampaignRepo.AddRecord(campaigns);
            return true;
        }

        public Campaigns OneCampaign(int campaignId)
        {
            return genericCampaignRepo.GetRecord(campaignId);
        }

        public bool CloseCampagin(Campaigns campaign)
        {
            genericCampaignRepo.UpdateRecord(campaign);
            return true;
        }

        //PRODUCTS
        public bool AddProducts(Products products)
        {
            if (string.IsNullOrWhiteSpace(products.Description)) products.Description = "None";
            genericProductRepo.AddRecord(products);
            return true;
        }

        public void DeleteProduct(int productId)
        {
            genericProductRepo.DeleteRecord(productId);
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return genericProductRepo.GetAllRecords();
        }

        public Products OneProduct(int productId)
        {
            return genericProductRepo.GetRecord(productId);
        }

        //REPORTS
        public IEnumerable<Leads> ViewLeadByCampaign(int campaignId)
        {
            return _leadsRepo.ViewLeadsByCampaign(campaignId);
        }

        public IEnumerable<Campaigns> ViewCampaignByExecutive()
        {
            return _campaignsRepo.ViewCampaignsByExec();
        }
    }
}