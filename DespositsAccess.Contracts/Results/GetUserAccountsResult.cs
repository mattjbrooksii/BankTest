using AccountsAccess.Contracts.Models;

namespace AccountsAccess.Contracts.Results
{
    public class GetUserAccountsResult
    {
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public IEnumerable<Account> UserAccounts { get; set; }
    }
}
