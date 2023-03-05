namespace BankClient.Models
{
    public class CreateAccountRequestMessage
    {
        public string UserName { get; set; }
        public decimal StartingFunds { get; set; }
    }
}
