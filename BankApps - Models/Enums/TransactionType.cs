using System.ComponentModel;

namespace BankApps___Models.Enums
{
    public enum TransactionType
    {
        [Description("Transfer Fund")]
        Transfer = 1,
        [Description("Withdraw Fund")]
        Withdrawal,
        [Description("Deposit")]
        Deposit,
    }
}
