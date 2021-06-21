using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface ICampaignsRepo
    {
        bool AddCampaign(Campaigns campaign);

        List<Campaigns> ViewCampaignsByExec();

        List<Campaigns> ViewCampaignsByAssigned();

        bool CloseCampaign(int cId);

        bool CampaignStatusCheck(int cId);

        Campaigns OneCampaign(int cId);

        List<Campaigns> ViewAllCampaigns();
    }
}
