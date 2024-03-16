namespace BankTests;

[Trait("Category", "Account Tests")]
public class SavingAccountTests : BaseAccountTests
{
    protected override Account CreateAccount(decimal initialBalance) => new SavingsAccount(initialBalance);
}