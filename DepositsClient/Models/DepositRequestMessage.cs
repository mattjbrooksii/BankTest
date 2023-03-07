namespace BankClient.Models
{
    public class DepositRequestMessage
    {
        public string AccountId { get; set; }
        public decimal DepositAmount { get; set; }
    }
}
