namespace BankTests;

public class CheckingAccountDepositTests
{
    private static readonly Faker Faker = new(Constants.Locale);

    private static (decimal InitialBalance, decimal Limit, Account Account) CreatePositiveBalanceAccount()
    {
        var initBalance = Faker.Random.Decimal(0, 1_000_000);
        var limit = Faker.Random.Decimal(0, 100_000);
        var account = new CheckingAccount(initBalance, limit);
        return (initBalance, limit, account);
    }

    public static (decimal InitialBalance, decimal Limit, Account Account) CreateNegativeBalanceAccount()
    {
        var initBalance = Faker.Random.Decimal(-100_000, 0);
        var limit = Faker.Random.Decimal(0, 100_000);
        var account = new CheckingAccount(initBalance, limit);
        return (initBalance, limit, account);
    }

    [Fact]
    public void Deposit_IncrementsBalance_WhenReceivesValidAmountAndAccountHasPositiveBalance()
    {
        // Arrange
        var (initialBalance, limit, account) = CreatePositiveBalanceAccount();
        var amount = Faker.Random.Decimal(0, 100_000);
        var expected = initialBalance + limit + amount;
        account.Deposit(amount);

        // Act
        var sut = account.GetBalance();

        // Assert
        sut.Should().Be(expected);
    }

    [Fact]
    public void Deposit_IncrementsBalance_WhenReceivesValidAmountAndAccountHasNegativeBalance()
    {
        // Arrange
        var (initialBalance, limit, account) = CreateNegativeBalanceAccount();
        var amount = Faker.Random.Decimal(0, 100_000);
        var expected = initialBalance + limit + amount;
        account.Deposit(amount);

        // Act
        var sut = account.GetBalance();

        // Assert
        sut.Should().Be(expected);
    }
}