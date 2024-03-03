namespace BankProject;

public class Account
{
    private decimal _balance;

    public Account(decimal initBalance)
    {
        _balance = initBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        _balance += amount;
    }

    public virtual bool Withdraw(decimal amount)
    {
        var result = false;
        if (amount > _balance) return result;
        
        _balance -= amount;
        result = true;
        return result;
    }

    public virtual decimal GetBalance() => _balance;
}