using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface ILeadsRepo
    {
        bool AddLeads(Leads leads);

        List<Leads> ViewLeadsToExec();

        List<Leads> ViewLeadsByCampaign(int cId);

        Leads GetALead(int leadID);

        bool FollowLead(int leadID, string newStatus);
    }
}
