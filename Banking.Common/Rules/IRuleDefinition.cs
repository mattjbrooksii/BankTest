namespace Banking.Common.Rules
{
    public interface IRuleDefinition
    {
        public RuleResult Execute(RuleContext source);
    }
}
