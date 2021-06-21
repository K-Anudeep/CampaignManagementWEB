using System;
using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories;

namespace MarketingManagement.API.Services
{
    public class ExecutiveService : IExecutiveService
    {
        LeadsRepo leadsRepo = null;
        CampaignsRepo campaignsRepo = null;
        SalesRepo salesRepo = null;

        public bool AddLeads(Leads leads)
        {
            throw new NotImplementedException();
        }

        public bool AddSales(Sales sales)
        {
            throw new NotImplementedException();
        }

        public bool CampaignStatusCheck(int cID)
        {
            throw new NotImplementedException();
        }

        public bool CheckLead(int leadID)
        {
            throw new NotImplementedException();
        }

        public bool FollowLead(int lID, string newStatus)
        {
            throw new NotImplementedException();
        }

        public List<Campaigns> ViewCampaignsAssigned()
        {
            throw new NotImplementedException();
        }

        public List<Leads> ViewLeads()
        {
            throw new NotImplementedException();
        }

        public List<Sales> ViewSales()
        {
            throw new NotImplementedException();
        }
    }
}
