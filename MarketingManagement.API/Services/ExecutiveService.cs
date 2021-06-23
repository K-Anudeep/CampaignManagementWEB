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
        private readonly GenericRepo<Sales> _genericSalesRepo;
        private readonly GenericRepo<Leads> _genericLeadsRepo;
        private readonly GenericRepo<Campaigns> _genericCampaignRepo;

        public ExecutiveService(MarketingMgmtDBContext context)
        {
            //Generic Repo for Campaigns
            _genericCampaignRepo = new GenericRepo<Campaigns>(context);
            //Generic Repo for Leads
            _genericLeadsRepo = new GenericRepo<Leads>(context);
            _leadsRepo = new LeadsRepo(context);
            //Direct Campaign Repo
            _campaignsRepo = new CampaignsRepo(context);
            _genericSalesRepo = new GenericRepo<Sales>(context);
        }

        //LEADS

        public bool AddLeads(Leads leads)
        {
            _genericLeadsRepo.AddRecord(leads);
            return true;
        }

        public bool FollowLead(Leads leads)
        {
            _genericLeadsRepo.UpdateRecord(leads);
            return true;
        }

        public IEnumerable<Leads> ViewLeads(int userId)
        {
            return _leadsRepo.ViewLeadsToExec(userId);
        }

        //SALES

        public bool AddSales(Sales sales)
        {
            _genericSalesRepo.AddRecord(sales);
            return true;
        }

        public IEnumerable<Sales> ViewSales()
        {
            return _genericSalesRepo.GetAllRecords();
        }

        //CAMPAIGNS

        public IEnumerable<Campaigns> ViewCampaignsAssigned(int userId)
        {
            return _campaignsRepo.ViewCampaignsByAssigned(userId);
        }
    }
}
