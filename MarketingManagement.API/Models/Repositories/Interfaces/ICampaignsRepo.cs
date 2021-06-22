using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface ICampaignsRepo
    {
        bool AddCampaign(Campaigns campaign);

        IEnumerable<Campaigns> ViewCampaignsByExec();

        IEnumerable<Campaigns> ViewCampaignsByAssigned(int userId);

        bool CloseCampaign(int cId);

        bool CampaignStatusCheck(int cId);

        Campaigns OneCampaign(int cId);

        IEnumerable<Campaigns> ViewAllCampaigns();
    }
}
