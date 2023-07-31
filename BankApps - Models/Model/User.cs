using System.ComponentModel.DataAnnotations;

namespace BankApps___Models.Model
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public List<Account> UserAccounts { get; set; }
    }
}
