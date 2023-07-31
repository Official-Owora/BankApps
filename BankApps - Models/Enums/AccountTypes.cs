using System.ComponentModel;

namespace BankApps___Models.Enums
{
    public enum AccountTypes
    {
        [Description("Savings Account")]
        SavingsAccount = 1,
        [Description("Current Account")]
        CurrentAccount,
    }
}
