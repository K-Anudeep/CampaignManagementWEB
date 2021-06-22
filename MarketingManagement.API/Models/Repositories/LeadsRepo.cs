﻿using System;
using System.Collections.Generic;
using MarketingManagement.API.Models.Repositories.Interfaces;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.DataContext;
using System.Linq;
using Microsoft.AspNetCore.Http;

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
            return _context.Leads.Find(leadID);
        }

        public IEnumerable<Leads> ViewLeadsByCampaign(int campaignId)
        {
            var leads = _context.Leads.ToList();

            //Gets Leads that are assigend to the specified Campaign
            return from l in leads
                   where l.CampaignID == campaignId
                   select l;
        }

        public IEnumerable<Leads> ViewLeadsToExec(int userId)
        {
            //SELECT l.* FROM Leads as l INNER JOIN Campaign as c ON l.CampaignID = c.CampaignID WHERE c.AssignedTo = @UserID

            // Gets Leads that are assigned to current session user. 
            return _context.Leads.Where(l => l.CampaignID == l.CampaignsReference.CampaignID
                                                && l.CampaignsReference.AssignedTo == userId);
        }
    }
}