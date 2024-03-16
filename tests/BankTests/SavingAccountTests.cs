namespace BankTests;

public class SavingAccountTests : AccountTests
{
    protected override Account CreateAccount(decimal initialBalance) => new SavingsAccount(initialBalance);
}