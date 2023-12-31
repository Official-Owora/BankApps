﻿using BankApps___Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApps___Models.Model
{
    public class Transaction : BaseEntity
    {
        public string AccountNumber { get; set; }
        public string TransactionId { get; set; }
        public string TransactionDescription { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public Status TransactionStatus { get; set; }
        [Column(TypeName = "money")]
        public decimal TransactionAmount { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string ReceiverName { get; set; }
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
       
    }
}
