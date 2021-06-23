using System;
using System.Collections.Generic;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories;

namespace MarketingManagement.API.Services
{
    public class ExecutiveService : IExecutiveService
    {
        private readonly LeadsRepo _leadsRepo;
        private readonly CampaignsRepo _campaignsRepo;
        private readonly GenericRepo<Sales> genericSalesRepo;
        private readonly GenericRepo<Leads> genericLeadsRepo;
        private readonly GenericRepo<Products> genericProductRepo;
        private readonly GenericRepo<Campaigns> genericCampaignRepo;

        public ExecutiveService(MarketingMgmtDBContext context)
        {
            //Generic Repo for Products
            genericProductRepo = new GenericRepo<Products>(context);
            //Generic Repo for Campaigns
            genericCampaignRepo = new GenericRepo<Campaigns>(context);
            //Generic Repo for Leads
            genericLeadsRepo = new GenericRepo<Leads>(context);
            _leadsRepo = new LeadsRepo(context);
            //Direct Campaign Repo
            _campaignsRepo = new CampaignsRepo(context);
        }

        //LEADS

        public bool AddLeads(Leads leads)
        {
            genericLeadsRepo.AddRecord(leads);
            return true;
        }

        public bool FollowLead(Leads leads)
        {
            genericLeadsRepo.UpdateRecord(leads);
            return true;
        }

        public IEnumerable<Leads> ViewLeads(int userId)
        {
            return _leadsRepo.ViewLeadsToExec(userId);
        }

        //SALES

        public bool AddSales(Sales sales)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sales> ViewSales()
        {
            throw new NotImplementedException();
        }

        //CAMPAIGNS

        public IEnumerable<Campaigns> ViewCampaignsAssigned()
        {
            throw new NotImplementedException();
        }
    }
}
