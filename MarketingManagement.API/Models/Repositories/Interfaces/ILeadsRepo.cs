using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface ILeadsRepo
    {
        void AddLeads(Leads leads);

        IEnumerable<Leads> ViewLeadsToExec(int userId);

        IEnumerable<Leads> ViewLeadsByCampaign(int userId);

        Leads GetALead(int leadId);

        void FollowLead(int leadId, string newStatus);

        bool LeadStatusCheck(int leadId);
    }
}
