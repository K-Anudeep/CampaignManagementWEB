using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface ILeadsRepo
    {
        void AddLeads(Leads leads);

        List<Leads> ViewLeadsToExec();

        List<Leads> ViewLeadsByCampaign(int cId);

        void GetALead(int leadID);

        void FollowLead(int leadID, string newStatus);
    }
}
