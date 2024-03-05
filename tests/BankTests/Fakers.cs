namespace BankTests;

public static class Fakers
{
    public static BankFaker Bank => new();
    public static CustomerFaker Customer => new();
    public static AccountFaker Account => new();
    public static PositiveBalanceCheckingAccountFaker PositiveBalanceCheckingAccount => new();
    
    public class BankFaker : Faker<Bank>
    {
        public BankFaker() : base(Constants.Locale)
        {
            CustomInstantiator(f => new Bank(f.Random.String(Name.MinLength, Name.MaxLength)));
        }
    }

    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker() : base(Constants.Locale)
        {
            CustomInstantiator(f => new Customer(f.Person.FirstName,
                                                 f.Person.LastName,
                                                 f.Address.FullAddress(),
                                                 new AccountFaker().Generate()));
        }
    }

    public class AccountFaker : Faker<Account>
    {
        public AccountFaker() : base(Constants.Locale)
        {
            CustomInstantiator(f => new Account(f.Random.Decimal(1_000, 1_000_000)));
        }
    }

    public class PositiveBalanceCheckingAccountFaker : Faker<CheckingAccount>
    {
        public PositiveBalanceCheckingAccountFaker() : base(Constants.Locale)
        {
            CustomInstantiator(f =>
            {
                var limit = f.Random.Decimal(0, 1_000_000);
                var initBalance = f.Random.Decimal(limit);
                var account = new CheckingAccount(initBalance, limit);
                return account;
            });
        }
    }
}