using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Repositories;

namespace MarketingManagement.API.Models.Validations
{
    public class DataChecks
    {
        private readonly CampaignsRepo campaignsRepo;
        private readonly LeadsRepo leadsRepo;
        private readonly ProductRepo productRepo;

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