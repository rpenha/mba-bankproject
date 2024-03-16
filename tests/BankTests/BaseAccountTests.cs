namespace BankTests;

[Trait("Category", "Account Tests")]
public abstract class BaseAccountTests
{
    private static readonly Faker Faker = new(Constants.Locale);
    private readonly decimal _initialBalance;

    protected BaseAccountTests()
    {
        _initialBalance = Faker.Random.Decimal(0m, 1_000_000);
    }

    protected abstract Account CreateAccount(decimal initialBalance);

    [Fact]
    public void Deposit_ShouldIncrementBalance_WithValidAmount()
    {
        // Arrange
        var deposit = Faker.Random.Decimal(0m, 1_000_000);
        var expected = _initialBalance + deposit;

        // Act
        var account = CreateAccount(_initialBalance);
        account.Deposit(deposit);

        // Assert
        account.GetBalance().Should().Be(expected);
    }

    [Fact]
    public void Withdraw_ShouldReturnFalse_WhenAccountHasEnoughBalance()
    {
        // Arrange
        var amount = Faker.Random.Decimal(_initialBalance, decimal.MaxValue);
        var account = CreateAccount(_initialBalance);
        var expected = account.GetBalance();

        // Act
        var sut = account.Withdraw(amount);

        // Assert
        sut.Should().Be(false);
        account.GetBalance().Should().Be(expected);
    }

    [Fact]
    public void Withdraw_SholdReturnFalse_WhenAccountHasntEnoughBalance()
    {
        // Arrange
        var amount = Faker.Random.Decimal(0, _initialBalance);
        var account = CreateAccount(_initialBalance);
        var expected = account.GetBalance() - amount;

        // Act
        var sut = account.Withdraw(amount);

        // Assert
        sut.Should().Be(true);
        account.GetBalance().Should().Be(expected);
    }

    [Fact]
    public void Balance_ShouldReturn_ActualAccountBalance()
    {
        // Arrange
        var expected = _initialBalance;

        // Act
        var sut = CreateAccount(_initialBalance);

        // Assert
        sut.GetBalance().Should().Be(expected);
    }
}