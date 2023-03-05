namespace BankClient.Models
{
    public class DeleteAccountRequestMessage
    {
        public string AccountId { get; set; }
        public string HolderName { get; set; }
    }
}
