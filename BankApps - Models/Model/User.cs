using System.ComponentModel.DataAnnotations;

namespace BankApps___Models.Model
{
    public class User : BaseEntity
    {
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public List<Account> Accounts { get; set; }

        
    }
}
