﻿using System;
using System.Collections.Generic;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories;

namespace MarketingManagement.API.Services
{
    public class AdminServices : IAdminServices
    {        
        private readonly UserRepo userRepo;
        private readonly LeadsRepo _leadsRepo;
        private readonly CampaignsRepo _campaignsRepo;
        private readonly GenericRepo<Users> genericUserRepo;
        private readonly GenericRepo<Products> genericProductRepo;
        private readonly GenericRepo<Campaigns> genericCampaignRepo;

        public AdminServices(MarketingMgmtDBContext context)
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

        public IEnumerable<Campaigns> ViewCampaingByExecutive()
        {
            return _campaignsRepo.ViewCampaignsByExec();
        }
    }
}
