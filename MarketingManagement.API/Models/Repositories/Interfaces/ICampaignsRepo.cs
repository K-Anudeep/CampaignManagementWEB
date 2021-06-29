using System.Collections;
using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface ICampaignsRepo
    {
        bool AddCampaign(Campaigns campaign);

        IEnumerable ViewCampaignsByExec();

        IEnumerable<Campaigns> ViewCampaignsByAssigned(int userId);

        bool CloseCampaign(int campaignId);

        bool SelfCampaignCheck(int campaignId, int userId);

        bool CampaignStatusCheck(int campaignId);

        Campaigns OneCampaign(int campaignId);

        IEnumerable<Campaigns> ViewAllCampaigns();
    }
}