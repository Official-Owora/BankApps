using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using BankApps___Models.Enums;

namespace BankApps___Models.Model
{
    public class Account : BaseEntity   
    {
        public int UserId { get; set; }
        [Column(TypeName = "money")]
        public decimal AccountBalance { get; set; }
        public AccountTypes AccountType { get; set; }
        public string AccountNumber { get; set; }
        List<Transaction> Transactions { get; set; }
    }
}
