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
            if (campaignsRepo.OneCampaign(campaignId) != null)
            {
                return true;
            }
            else
                return false;
        }

        ////public bool CheckUser(int userID)
        ////{
        ////    Users check = userRepo.OneUser(userID);
        ////    if (check != null)
        ////    {
        ////        return true;
        ////    }
        ////    else
        ////    {
        ////        return false;
        ////    }
        ////}

        public bool CheckLeadStatus(int leadId)
        {
            return leadsRepo.LeadStatusCheck(leadId);
        }

        //public bool SalesLead(int leadID)
        //{
        //    Leads check = leadsRepo.GetALead(leadID);
        //    if (check != null)
        //    {
        //        var check1 = leadsRepo.GetALead(leadID);
        //        if (check1 != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool CheckProduct(int productId)
        {
            var check = productRepo.OneProduct(productId);
            return check != null;
        }

        //public bool AdminCheck(int userID)
        //{
        //    //To check if user is Admin
        //    Users check = userRepo.OneUser(userID);
        //    if (check.IsAdmin == 1)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        ////public bool EmailCheck(string email)
        ////{
        ////    var check = new EmailAddressAttribute();
        ////    if (check.IsValid(email))
        ////    {
        ////        return true;
        ////    }
        ////    else
        ////        return false;
        ////}
        //public bool EmailCheck(string email)
        //{
        //    string regexEmail = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,63}$";
        //    if (Regex.IsMatch(email.ToString(), regexEmail))
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public bool PhoneNoCheck(string phone)
        //{
        //    if (Regex.IsMatch(phone, @"^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[6789]\d{9}$"))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
