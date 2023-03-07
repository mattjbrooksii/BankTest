namespace StorageImplementation.Accounts
{
    internal class Account_TestData
    {
        public Account_TestData()
        {
            TestData = new()
            {
                new AccountEntity()
                {
                    AccountId = Guid.NewGuid().ToString(),
                    AccountBalance = 500.00m,
                    User = new UserEntity
                    {
                        Name = "John Doe",
                        Id = Guid.NewGuid().ToString(),
                    }
                },
                new AccountEntity()
                {
                    AccountId = Guid.NewGuid().ToString(),
                    AccountBalance = 100000.00m,
                    User = new UserEntity
                    {
                        Name = "Jane Doe",
                        Id = Guid.NewGuid().ToString(),
                    }
                },
                new AccountEntity()
                {
                    AccountId = Guid.NewGuid().ToString(),
                    AccountBalance = 100.00m,
                    User = new UserEntity
                    {
                        Name = "Sal Doe",
                        Id = Guid.NewGuid().ToString(),
                    }
                },
            };
        }

        public List<AccountEntity> TestData { get; set; }            
    }
}
