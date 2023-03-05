namespace StorageImplementation.Accounts
{
    public class UserEntity
    {
        public string Id { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
