using BankApps___Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApps___Models.Model
{
    public class Transaction : BaseEntity
    {
        public string AccountNumber { get; set; }
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        public string TransactionDescription { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public Status TransactionStatus { get; set; }
        [Column(TypeName = "money")]
        public decimal TransactionAmount { get; set; }
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
       
        
    }
}
