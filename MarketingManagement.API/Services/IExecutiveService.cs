using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Services
{
    public interface IExecutiveService
    {
        //SALES
        bool AddSales(Sales sales);

        IEnumerable<Sales> ViewSales();

        //LEADS

        bool AddLeads(Leads leads);

        bool FollowLead(Leads leads);

        IEnumerable<Leads> ViewLeads(int userId);

        //CAMPAIGNS

        IEnumerable<Campaigns> ViewCampaignsAssigned();
    }
}
