using Banking.Common.Rules;
using AccountsAccess.Contracts.Models;
using AccountsAccess.Contracts.Requests;

namespace AccountsAccess.Service.Rules
{
    internal class TransactionRuleContext : RuleContext
    {
        public Account UserAccount { get; set; }
        public AccountRequestBase Request { get; set; }
    }
}
