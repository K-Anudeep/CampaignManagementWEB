using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Services
{
    public interface IExecutiveService
    {
        bool AddSales(Sales sales);

        List<Sales> ViewSales();

        bool AddLeads(Leads leads);

        bool CheckLead(int leadID);

        bool CampaignStatusCheck(int cID);

        bool FollowLead(int lID, string newStatus);

        List<Leads> ViewLeads();

        List<Campaigns> ViewCampaignsAssigned();

    }
}
