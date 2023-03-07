
using AccountsAccess.Contracts.Models;
using AccountsAccess.Service.Repository;
using Banking.Common;
using StorageImplementation.Adapters;

namespace StorageImplementation.Accounts
{
    public class Accounts_Mock : IAccountsRepository
    {
        private readonly IAdapter<AccountEntity, Account> _adapter;
        private Account_TestData _data;
        public Accounts_Mock() 
        {
            _adapter = new AccountEntityToAccount();
            _data = new Account_TestData();
        }

        public Task DeleteAccount(string accountId)
        {
            var account = _data.TestData.FirstOrDefault(acc => acc.AccountId.Equals(accountId));
            if (account is not null)
            {
                _data.TestData.Remove(account);
            }

            return Task.CompletedTask;
        }

        public Task<Account> GetAccount(string accountId)
        {
            var r = _data.TestData.FirstOrDefault(x => x.AccountId.Equals(accountId));
            return Task.FromResult(_adapter.AdaptTo(r));
        }

        public Task<IEnumerable<Account>> GetAllAccounts(GetAccountsParameters param)
        {
            if (!string.IsNullOrEmpty(param.UserId))
            {
                return Task.FromResult(
                _data.TestData.Where(x => x.User.Id.Equals(param.UserId))
                .Select(y => _adapter.AdaptTo(y)));
            }

            return Task.FromResult(
                _data.TestData.Where(x => x.User.Name.Equals(param.UserFullName, StringComparison.OrdinalIgnoreCase))
                .Select(y => _adapter.AdaptTo(y)));
        }

        public Task<Account> SaveAccount(Account param)
        {
            var entityChanges = _adapter.AdaptFrom(param);

            var accountEntity = _data.TestData.FirstOrDefault(acc => acc.AccountId.Equals(entityChanges.AccountId));
            if (accountEntity is null)
            {
                _data.TestData.Add(entityChanges);
                return Task.FromResult(_adapter.AdaptTo(entityChanges));
            }

            var index = _data.TestData.FindIndex(x => x.AccountId.Equals(accountEntity.AccountId));
            if (index != -1)
            {
                _data.TestData[index] = entityChanges;
            }

            accountEntity = entityChanges;

            return Task.FromResult(_adapter.AdaptTo(accountEntity));
        }
    }
}
