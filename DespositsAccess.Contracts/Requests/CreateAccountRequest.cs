using AccountsAccess.Contracts.Requests;

namespace AccountsAccess.Contracts.Requests
{
    public class CreateAccountRequest : AccountRequestBase
    {
        public decimal StartingFunds { get; set; }
        public string UserName { get; set; }
    }
}
