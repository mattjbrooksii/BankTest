using AccountsAccess.Contracts.Models;

namespace AccountsAccess.Contracts.Results
{
    public abstract class AccountResultBase
    {
        public string Message { get; set; }
        public bool TransactionSucceeded { get; set; }
        public Account Account { get; set; }
    }
}
