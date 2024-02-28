using System.Collections.Immutable;

namespace BankProject;

public class Bank
{
    private readonly List<Customer> _customerList = new();

    public Bank(string name)
    {
        Name = new Name(name);
    }

    public string Name { get; }

    public void AddCustomer(Customer customer)
    {
        if (customer is null)
            throw new ArgumentException(nameof(customer));

        _customerList.Add(customer);
    }

    public Customer GetCustomer(int position)
    {
        if (position < 0 || position > _customerList.Count)
            throw new ArgumentOutOfRangeException(nameof(position));

        return _customerList[position];
    }

    public IList<Customer> GetCustomerList()
    {
        return _customerList.ToImmutableList();
    }
}