namespace NeradomKetvirtoLab3.Models
{
    public class UserWithAuth
    {
        public UserWithAuth(User user, string securityCode)
        {
            this.User = user;
            this.SecurityCode = securityCode;
        }

        public User User { get; set; }
        public string SecurityCode { get; set; }
    }
}
