namespace BankTests;

[Trait("Category", "Account Tests")]
public class CheckingAccountTests
{
    private static readonly Faker Faker = new(Constants.Locale);
    
    public static IEnumerable<object[]> DepositValidAmountArguments
    {
        get
        {
            yield return [0m, 0m, 1000m, 1000m];
            yield return [0m, 500m, 1000m, 1500m];
            yield return [500m, 500m, 1000m, 2000m];
        }
    }

    [Theory]
    [MemberData(nameof(DepositValidAmountArguments))]
    public void Deposit_ShouldIncrementBalance_WhenAmountIsValid(decimal initialBalance, decimal limit, decimal amount, decimal expected)
    {
        // Arrange
        var account = new CheckingAccount(initialBalance, limit);
        account.Deposit(amount);

        // Act
        var sut = account.GetBalance();

        // Assert
        sut.Should().Be(expected);
    }


    public static IEnumerable<object[]> NegativeBalanceArguments
    {
        get
        {
            yield return [500m, 500m, 1000m, 1000m];
            yield return [500m, 500m, 500m, 500m];
        }
    }

    [Theory]
    [MemberData(nameof(NegativeBalanceArguments))]
    public void Deposit_ShouldIncrementBalance_WhenAmountExceedsNegativeBalance(decimal negativeBalance, decimal limit, decimal amount, decimal expected)
    {
        // Arrange
        var account = new CheckingAccount(0, limit);
        account.Withdraw(negativeBalance);
        account.Deposit(amount);

        // Act
        var sut = account.GetBalance();

        // Assert
        sut.Should().Be(expected);
    }
    public static IEnumerable<object[]> WithdrawValidAmountArguments
    {
        get
        {
            yield return [1000m, 0m, 1000m, 0m, 0m];
            yield return [1000m, 500m, 1000m, 500m, 500m];
            yield return [500m, 500m, 1000m, 0m, 0m];
        }
    }

    [Theory]
    [MemberData(nameof(WithdrawValidAmountArguments))]
    public void Withdraw_ShouldDecrementBalance_WhenAccountHasFunds(decimal initialBalance,
                                                                    decimal limit,
                                                                    decimal widthdrawAmount,
                                                                    decimal expectedBalance,
                                                                    decimal expectedLimit
    )
    {
        // Arrange
        var account = new CheckingAccount(initialBalance, limit);

        // Act
        var sut = account.Withdraw(widthdrawAmount);

        // Assert
        sut.Should().BeTrue();
        account.GetBalance().Should().Be(expectedBalance);
        account.GetCurrentLimit().Should().Be(expectedLimit);
    }

    [Fact]
    public void Withdraw_ShouldReturnFalse_WhenAccountHasntEnoughBalance()
    {
        // Arrange
        var initialBalance = 1000;
        var withdrawAmount = 3000;
        var limit = 1000;
        var account = new CheckingAccount(initialBalance, limit);
        
        // Act
        var sut = account.Withdraw(withdrawAmount);

        // Assert
        sut.Should().BeFalse();
        account.GetBalance().Should().Be(initialBalance + limit);
        account.GetCurrentLimit().Should().Be(limit);
        account.GetTotalLimit().Should().Be(limit);
    }
}