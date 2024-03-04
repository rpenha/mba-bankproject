namespace BankTests;

public static class Fakers
{
    public static BankFaker Bank => new();
    public static CustomerFaker Customer => new();
    public static AccountFaker Account => new();
    
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
}