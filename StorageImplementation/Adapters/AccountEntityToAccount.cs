using AccountsAccess.Contracts.Models;
using Banking.Common;
using StorageImplementation.Accounts;

namespace StorageImplementation.Adapters
{
    public class AccountEntityToAccount : IAdapter<AccountEntity, Account>
    {
        public AccountEntity AdaptFrom(Account source)
        {
            var names = source.UserFullName.Split(' ');

            return new AccountEntity
            {
                AccountBalance = source.Balance,
                AccountId = source.Id,
                User = new UserEntity
                {
                    Id = source.UserId,
                    FirstName = names[0],
                    LastName = names[1]
                }
            };
        }

        public Account AdaptTo(AccountEntity source)
        {
            return new Account
            {
                Balance = source.AccountBalance,
                UserId = source.User.Id,
                UserFullName = source.User.FullName,
                Id = source.AccountId
            };
        }
    }
}
