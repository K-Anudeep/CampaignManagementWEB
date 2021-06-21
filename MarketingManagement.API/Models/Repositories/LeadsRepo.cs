using System;
using System.Collections.Generic;
using MarketingManagement.API.Models.Repositories.Interfaces;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories
{
    public class LeadsRepo : ILeadsRepo
    {
        public bool AddLeads(Leads leads)
        {
            throw new NotImplementedException();
        }

        public bool FollowLead(int leadID, string newStatus)
        {
            throw new NotImplementedException();
        }

        public Leads GetALead(int leadID)
        {
            throw new NotImplementedException();
        }

        public List<Leads> ViewLeadsByCampaign(int cId)
        {
            throw new NotImplementedException();
        }

        public List<Leads> ViewLeadsToExec()
        {
            throw new NotImplementedException();
        }
    }
}




