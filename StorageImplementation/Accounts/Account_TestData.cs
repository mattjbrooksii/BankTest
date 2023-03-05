namespace StorageImplementation.Accounts
{
    internal static class Account_TestData
    {
        static Account_TestData()
        {
            TestData = new()
            {
                new AccountEntity()
                {
                    AccountId = Guid.NewGuid().ToString(),
                    AccountBalance = 500.00m,
                    User = new UserEntity
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Id = Guid.NewGuid().ToString(),
                    }
                },
                new AccountEntity()
                {
                    AccountId = Guid.NewGuid().ToString(),
                    AccountBalance = 100000.00m,
                    User = new UserEntity
                    {
                        FirstName = "Jane",
                        LastName = "Doe",
                        Id = Guid.NewGuid().ToString(),
                    }
                },
                new AccountEntity()
                {
                    AccountId = Guid.NewGuid().ToString(),
                    AccountBalance = 100.00m,
                    User = new UserEntity
                    {
                        FirstName = "Sal",
                        LastName = "Goodman",
                        Id = Guid.NewGuid().ToString(),
                    }
                },
            };
        }

        public static List<AccountEntity> TestData { get; set; }            
    }
}
