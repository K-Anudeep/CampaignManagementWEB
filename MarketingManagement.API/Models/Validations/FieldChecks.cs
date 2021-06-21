namespace MarketingManagement.API.Models.Validations
{
    public class FieldChecks
    {
        public bool StringCheck(string input, out string result)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                result = null;
                return false;
            }
            else
            {
                result = input;
                return true;
            }
        }
    }
}
