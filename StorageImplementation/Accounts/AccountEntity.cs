namespace StorageImplementation.Accounts
{
    public class AccountEntity
    {
        public string AccountId { get; set; }
        public UserEntity User { get; set; }
        public decimal AccountBalance { get; set; }

    }
}
