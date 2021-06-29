namespace MarketingManagement.API.Models.Entities
{
    public class Session
    {
        private static int _userSessionId;

        public int UserSessionId
        {
            get => _userSessionId;
            set => _userSessionId = value;
        }
    }
}