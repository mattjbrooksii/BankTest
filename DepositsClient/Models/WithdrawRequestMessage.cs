namespace BankClient.Models
{
    public class WithdrawRequestMessage
    {
        public string AccountId { get; set; }
        public decimal WithdrawAmount { get; set; }
    }
}
