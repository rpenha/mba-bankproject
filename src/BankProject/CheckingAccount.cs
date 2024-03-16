namespace BankProject;

public class CheckingAccount : Account
{
    private readonly decimal _totalLimit;
    private decimal _currentLimit;

    public CheckingAccount(decimal initBalance, decimal limit) : base(initBalance)
    {
        _totalLimit = limit;
        _currentLimit = _totalLimit;
    }

    public override decimal GetBalance() => base.GetBalance() + _currentLimit;

    public override void Deposit(decimal amount)
    {
        var isUsingLimit = IsUsingLimit();
        var usedLimit = GetUsedLimit();
        var depositExceedsUsedLimit = amount > usedLimit;
        var constraints = (isUsingLimit, depositExceedsUsedLimit);

        switch (constraints)
        {
            case (false, _):
                base.Deposit(amount);
                break;
            case (true, false):
                _currentLimit += amount;
                break;
            case (true, true):
                amount -= usedLimit;
                _currentLimit = _totalLimit;
                base.Deposit(amount);
                break;
        }
    }

    public override bool Withdraw(decimal amount)
    {
        var balance = base.GetBalance();
        
        if (amount <= balance)
        {
            return base.Withdraw(amount);
        }

        var currentLimit = GetCurrentLimit();
        if (amount > balance + currentLimit) return false;
        _currentLimit -= amount - balance;
        return base.Withdraw(balance);
    }

    private decimal GetUsedLimit() => _totalLimit - _currentLimit;

    private bool IsUsingLimit() => _currentLimit < _totalLimit;

    public decimal GetTotalLimit() => _totalLimit;

    public decimal GetCurrentLimit() => _currentLimit;
}