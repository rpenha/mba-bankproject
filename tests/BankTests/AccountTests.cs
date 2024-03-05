namespace BankTests;

public class AccountTests
{
    private static readonly Faker Faker = new(Constants.Locale);
    private readonly decimal _initialBalance;

    public AccountTests()
    {
        _initialBalance = Faker.Random.Decimal(0m, 1_000_000);
    }

    [Fact]
    public void Deposit_ShouldIncrementBalance()
    {
        // Arrange
        var deposit = Faker.Random.Decimal(0m, 1_000_000);
        var expected = _initialBalance + deposit;

        // Act
        var account = new Account(_initialBalance);
        account.Deposit(deposit);

        // Assert
        account.GetBalance().Should().Be(expected);
    }

    [Fact]
    public void Withdraw_ReturnsFalse_WhenInsufficientBalance()
    {
        // Arrange
        var amount = Faker.Random.Decimal(_initialBalance, decimal.MaxValue);
        var account = new Account(_initialBalance);
        var expected = account.GetBalance();

        // Act
        var sut = account.Withdraw(amount);

        // Assert
        sut.Should().Be(false);
        account.GetBalance().Should().Be(expected);
    }

    [Fact]
    public void Withdraw_ReturnsFalse_WhenSufficientBalance()
    {
        // Arrange
        var amount = Faker.Random.Decimal(0, _initialBalance);
        var account = new Account(_initialBalance);
        var expected = account.GetBalance() - amount;

        // Act
        var sut = account.Withdraw(amount);

        // Assert
        sut.Should().Be(true);
        account.GetBalance().Should().Be(expected);
    }

    [Fact]
    public void Balance_Returns_CorrectValue()
    {
        // Arrange
        var expected = _initialBalance;

        // Act
        var sut = new Account(_initialBalance);

        // Assert
        sut.GetBalance().Should().Be(expected);
    }
}