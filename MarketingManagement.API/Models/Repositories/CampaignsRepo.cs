using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;

namespace MarketingManagement.API.Models.Repositories
{
    public class CampaignsRepo : ICampaignsRepo
    {
        private readonly MarketingMgmtDBContext _context;

        public CampaignsRepo(MarketingMgmtDBContext context)
        {
            _context = context;
        }

        public bool AddCampaign(Campaigns campaign)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        //Used by Executive to view his Campaigns
        public IEnumerable<Campaigns> ViewCampaignsByAssigned(int userId)
        {
            return _context.Campaigns.Where(v => v.AssignedTo == userId);
        }

        //Used by Admin to view a specific Exec's campaigns
        public IEnumerable<Campaigns> ViewCampaignsByExec()
        {
            //SELECT c.AssignedTo ,c.CampaignID, c.Name, c.Venue,c.StartedOn, c.CompletedOn, c.IsOpen,COUNT(C.Name)as Leads 
            //FROM Campaign AS c RIGHT JOIN Leads AS l ON l.CampaignID = c.CampaignID group by c.AssignedTo, c.CampaignID, c.Name,c.Venue,c.StartedOn, c.CompletedOn, c.IsOpen
            //ORDER BY c.AssignedTo
            return _context.Campaigns.FromSqlRaw("SELECT c.AssignedTo ,c.CampaignID, c.Name, c.Venue,c.StartedOn, c.CompletedOn, c.IsOpen,COUNT(C.Name)as Leads " +
                "FROM Campaign AS c RIGHT JOIN Leads AS l ON l.CampaignID = c.CampaignID group by c.AssignedTo, c.CampaignID, c.Name, c.Venue, c.StartedOn, c.CompletedOn, c.IsOpen " +
                "ORDER BY c.AssignedTo");
        }
    }
}
