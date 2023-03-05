
using AccountsAccess.Contracts.Models;
using AccountsAccess.Service.Repository;
using Banking.Common;
using StorageImplementation.Adapters;

namespace StorageImplementation.Accounts
{
    public class Accounts_Mock : IAccountsRepository
    {
        private readonly IAdapter<AccountEntity, Account> _adapter;
        public Accounts_Mock() 
        {
            _adapter = new AccountEntityToAccount();
        }

        public Task DeleteAccount(string accountId)
        {
            var account = Account_TestData.TestData.FirstOrDefault(acc => acc.AccountId.Equals(accountId));
            if (account is not null)
            {
                Account_TestData.TestData.Remove(account);
            }

            return Task.CompletedTask;
        }

        public Task<Account> GetAccount(string accountId)
        {
            var r = Account_TestData.TestData.FirstOrDefault(x => x.AccountId.Equals(accountId));
            return Task.FromResult(_adapter.AdaptTo(r));
        }

        public Task<IEnumerable<Account>> GetAllAccounts(GetAccountsParameters param)
        {
            if (!string.IsNullOrEmpty(param.UserId))
            {
                return Task.FromResult(
                Account_TestData.TestData.Where(x => x.User.Id.Equals(param.UserId))
                .Select(y => _adapter.AdaptTo(y)));
            }

            return Task.FromResult(
                Account_TestData.TestData.Where(x => x.User.FullName.Equals(param.UserFullName, StringComparison.OrdinalIgnoreCase))
                .Select(y => _adapter.AdaptTo(y)));
        }

        public Task<Account> SaveAccount(Account param)
        {
            var entityChanges = _adapter.AdaptFrom(param);

            var accountEntity = Account_TestData.TestData.FirstOrDefault(acc => acc.AccountId.Equals(entityChanges.AccountId));
            if (accountEntity is null)
            {
                Account_TestData.TestData.Add(entityChanges);
                return Task.FromResult(_adapter.AdaptTo(entityChanges));
            }

            accountEntity = entityChanges;

            return Task.FromResult(_adapter.AdaptTo(accountEntity));
        }
    }
}
