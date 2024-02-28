namespace BankProject;

public class Account
{
    private decimal _balance;

    public Account(decimal initBalance)
    {
        _balance = initBalance;
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        var result = false;
        if (amount > _balance) return result;
        
        _balance -= amount;
        result = true;
        return result;
    }

    public decimal GetBalance() => _balance;
}