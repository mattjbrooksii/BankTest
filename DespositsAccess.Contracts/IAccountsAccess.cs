using AccountsAccess.Contracts.Requests;
using AccountsAccess.Contracts.Results;
using AccountsAccess.Contracts.Requests;

namespace AccountsAccess.Contracts
{
    public interface IAccountsAccess
    {
        Task<CreateAccountResult> CreateAccount(CreateAccountRequest createRequest);
        Task<DeleteAccountResult> DeleteAccount(DeleteAccountRequest deleteRequest);
        Task<GetUserAccountsResult> GetAllAccountsForUser(GetUserAccountsRequest userAccountsRequest);
        Task<DepositResult> DepositToAccount(DepositRequest depositRequest);
        Task<WithdrawResult> WithdrawFromAccount(WithdrawRequest withdrawRequest);
    }
}
