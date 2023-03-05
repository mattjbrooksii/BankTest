using Banking.Common.Rules;

namespace AccountsAccess.Service.Rules
{
    internal class TransactionRulesExecutor : IRulesUtility
    {
        public IEnumerable<RuleResult> ExecuteRules(IEnumerable<IRuleDefinition> rules, RuleContext context)
        {
            var results = new List<RuleResult>();

            foreach (var rule in rules)
            {
                results.Add(rule.Execute(context));
            }

            return results;
        }
    }
}
