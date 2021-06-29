using System;
using System.Collections.Generic;
using System.Linq;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketingManagement.API.Models.Repositories
{
    public class CampaignsRepo : ICampaignsRepo
    {
        private readonly MarketingMgmtDbContext _context;

        public CampaignsRepo(MarketingMgmtDbContext context)
        {
            _context = context;
        }

        public bool AddCampaign(Campaigns campaign)
        {
            _context.Campaigns.Add(campaign);
            _context.SaveChanges();
            return true;
        }

        public bool SelfCampaignCheck(int campaignId, int userId)
        {
            var selfCheck = _context.Campaigns.SingleOrDefault(c => 
                                            c.CampaignID == campaignId && c.AssignedTo == userId);
            return selfCheck != null;
        }

        public bool CampaignStatusCheck(int campaignId)
        {
            var statusCheck = _context.Campaigns.Find(campaignId);
            return statusCheck.IsOpen;
        }

        public bool CloseCampaign(int cId)
        {
            throw new NotImplementedException();
        }

        public Campaigns OneCampaign(int campaignId)
        {
            return _context.Campaigns.Find(campaignId);
        }

        public IEnumerable<Campaigns> ViewAllCampaigns()
        {
            return _context.Campaigns.ToList();
        }

        //Used by Executive to view his Campaigns
        public IEnumerable<Campaigns> ViewCampaignsByAssigned(int userId)
        {
            return _context.Campaigns.Where(v => v.AssignedTo == userId);
        }

        //Used by Admin to view campaigns ordered by Executives
        public IEnumerable<Campaigns> ViewCampaignsByExec()
        {
            //SELECT c.AssignedTo ,c.CampaignID, c.Name, c.Venue,c.StartedOn, c.CompletedOn, c.IsOpen,COUNT(C.Name)as Leads 
            //FROM Campaign AS c RIGHT JOIN Leads AS l ON l.CampaignID = c.CampaignID group by c.AssignedTo, c.CampaignID, c.Name,c.Venue,c.StartedOn, c.CompletedOn, c.IsOpen
            //ORDER BY c.AssignedTo
            return _context.Campaigns.FromSqlRaw(
                "SELECT c.AssignedTo ,c.CampaignID, c.Name, c.Venue,c.StartedOn, c.CompletedOn, c.IsOpen,COUNT(C.Name)as Leads " +
                "FROM Campaign AS c RIGHT JOIN Leads AS l ON l.CampaignID = c.CampaignID group by c.AssignedTo, c.CampaignID, c.Name, c.Venue, c.StartedOn, c.CompletedOn, c.IsOpen " +
                "ORDER BY c.AssignedTo");
        }
    }
}