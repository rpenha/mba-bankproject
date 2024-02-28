namespace BankProject;

public class CheckingAccount : Account
{
    private decimal _totalLimit;
    private decimal _currentLimit;

    public CheckingAccount(decimal initBalance, decimal limit) : base(initBalance)
    {
        _totalLimit = limit;
        _currentLimit = _totalLimit;
    }

    public decimal GetBalance()
    {
        return base.GetBalance() + _currentLimit;
    }

    public void Deposit(decimal amount)
    {
        if (_currentLimit < _totalLimit)
        {
            decimal diference = _totalLimit - _currentLimit;
            if (diference > amount)
            {
                _currentLimit += amount;
            }
            else
            {
                _currentLimit = _totalLimit;
                base.Deposit(amount - diference);
            }
        }
        else
        {
            base.Deposit(amount);
        }
    }

    public bool Withdraw(decimal amount)
    {
        var result = false;
        if (amount <= base.GetBalance())
        {
            result = base.Withdraw(amount);
        }
        else if (amount <= GetBalance() + GetCurrentLimit())
        {
            _currentLimit -= GetBalance();
            result = base.Withdraw(GetBalance());
        }

        return result;
    }

    public decimal GetTotalLimit()
    {
        return _totalLimit;
    }

    public decimal GetCurrentLimit()
    {
        return _currentLimit;
    }
}