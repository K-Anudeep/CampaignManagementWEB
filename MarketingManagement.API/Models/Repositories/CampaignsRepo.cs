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

        public bool CampaignStatusCheck(int cId)
        {
            throw new NotImplementedException();
        }

        public bool CloseCampaign(int cId)
        {
            throw new NotImplementedException();
        }

        public Campaigns OneCampaign(int cId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Campaigns> ViewAllCampaigns()
        {
            throw new NotImplementedException();
        }

        //Used by Executive to view his Campaigns
        public IEnumerable<Campaigns> ViewCampaignsByAssigned(int userId)
        {
            throw new NotImplementedException();
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
