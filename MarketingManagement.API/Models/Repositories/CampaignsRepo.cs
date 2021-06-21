using System;
using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;

namespace MarketingManagement.API.Models.Repositories
{
    public class CampaignsRepo : ICampaignsRepo
    {
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

        public List<Campaigns> ViewAllCampaigns()
        {
            throw new NotImplementedException();
        }

        public List<Campaigns> ViewCampaignsByAssigned()
        {
            throw new NotImplementedException();
        }

        public List<Campaigns> ViewCampaignsByExec()
        {
            throw new NotImplementedException();
        }
    }
}
