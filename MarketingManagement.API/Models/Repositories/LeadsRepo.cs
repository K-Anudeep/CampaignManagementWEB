using System;
using System.Collections.Generic;
using MarketingManagement.API.Models.Repositories.Interfaces;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data;

namespace MarketingManagement.API.Models.Repositories
{
    public class LeadsRepo : ILeadsRepo
    {
        private readonly MarketingMgmtDBContext _context;

        public LeadsRepo(MarketingMgmtDBContext context)
        {
            _context = context;
        }

        public void AddLeads(Leads leads)
        {
            _context.Add(leads);
            _context.SaveChanges();
        }

        public void FollowLead(int leadID, string newStatus)
        {
            throw new NotImplementedException();
        }

        public Leads GetALead(int leadID)
        {
            return _context.Leads.Find(leadID) ;
        }

        public List<Leads> ViewLeadsByCampaign(int cId)
        {
            
        }

        public List<Leads> ViewLeadsToExec()
        {
            throw new NotImplementedException();
        }
    }
}




