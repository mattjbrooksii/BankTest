using AccountsAccess.Contracts.Models;
using Banking.Common;
using StorageImplementation.Accounts;

namespace StorageImplementation.Adapters
{
    public class AccountEntityToAccount : IAdapter<AccountEntity, Account>
    {
        public AccountEntity AdaptFrom(Account source)
        {

            return new AccountEntity
            {
                AccountBalance = source.Balance,
                AccountId = source.Id,
                User = new UserEntity
                {
                    Id = source.UserId,
                    Name = source.UserName
                }
            };
        }

        public Account AdaptTo(AccountEntity source)
        {
            return new Account
            {
                Balance = source.AccountBalance,
                UserId = source.User.Id,
                UserName = source.User.Name,
                Id = source.AccountId
            };
        }
    }
}
