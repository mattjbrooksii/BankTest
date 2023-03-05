using AccountsAccess.Contracts.Models;

namespace AccountsAccess.Service.Repository
{
    public interface IAccountsRepository
    {
        Task<Account> GetAccount(string accountId);
        Task<IEnumerable<Account>> GetAllAccounts(GetAccountsParameters param);
        Task<Account> SaveAccount(Account account);
        Task DeleteAccount(string accountId);
    }
}
