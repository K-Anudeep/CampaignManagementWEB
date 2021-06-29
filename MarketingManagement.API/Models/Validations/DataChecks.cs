using MarketingManagement.API.Models.Repositories;
using MarketingManagement.API.DataContext;

namespace MarketingManagement.API.Models.Validations
{
    public class DataChecks
    {
        CampaignsRepo campaignsRepo;
        LeadsRepo leadsRepo;
        ProductRepo productRepo;

        public DataChecks(MarketingMgmtDbContext context)
        {
            campaignsRepo = new CampaignsRepo(context);
            leadsRepo = new LeadsRepo(context);
            productRepo = new ProductRepo(context);
        }

        public bool CampaignStatusCheck(int campaignId)
        {
            return campaignsRepo.CampaignStatusCheck(campaignId);
        }

        public bool CheckCampaign(int campaignId)
        {
            return campaignsRepo.OneCampaign(campaignId) != null;
        }

        public bool CheckSelfCampaign(int campaignId, int userId)
        {
            return campaignsRepo.SelfCampaignCheck(campaignId, userId);
        }

        public bool CheckLeadStatus(int leadId)
        {
            return leadsRepo.LeadStatusCheck(leadId);
        }

        public bool CheckProduct(int productId)
        {
            var check = productRepo.OneProduct(productId);
            return check != null;
        }
    }
}
