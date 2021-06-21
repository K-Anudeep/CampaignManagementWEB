using System;
using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories;

namespace MarketingManagement.API.Services
{
    public class AdminServices : IAdminServices
    {
        ProductRepo productRepo = null;
        CampaignsRepo campaignsRepo = null;
        UserRepo userRepo = null;

        public bool AddCampaign(Campaigns campaigns)
        {
            throw new NotImplementedException();
        }

        public bool AddProducts(Products products)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(Users users)
        {
            throw new NotImplementedException();
        }

        public bool CloseCampagin(int cId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int pId)
        {
            throw new NotImplementedException();
        }

        public bool DiscontinueUser()
        {
            throw new NotImplementedException();
        }

        public List<Users> DisplayUsers()
        {
            throw new NotImplementedException();
        }

        public Campaigns OneCampaign(int cId)
        {
            throw new NotImplementedException();
        }

        public Products OneProduct(int pId)
        {
            throw new NotImplementedException();
        }

        public Users OneUser()
        {
            throw new NotImplementedException();
        }

        public List<Campaigns> ViewCampaingByExecutive()
        {
            throw new NotImplementedException();
        }

        public List<Leads> ViewLeadByCampaign(int cId)
        {
            throw new NotImplementedException();
        }

        public List<Products> ViewProducts()
        {
            throw new NotImplementedException();
        }
    }
}
