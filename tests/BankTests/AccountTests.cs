namespace BankTests;

[Trait("Category", "Account Tests")]
public class AccountTests : BaseAccountTests
{
    protected override Account CreateAccount(decimal initialBalance) => new(initialBalance);
}