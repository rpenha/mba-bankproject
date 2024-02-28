namespace BankProject;

public class Customer
{
    private string _firstName;
    private string _lastName;
    private string _address;
    private Account _account;
    private DateTime? _dateOfBirthday;

    public Customer(string firstName, string lastName, string address, Account account)
    {
        _firstName = firstName;
        _lastName = lastName;
        _address = address;
        _account = account;
    }

    public string GetFirstName() => _firstName;

    public void SetFirstName(string firstName) => _firstName = firstName;

    public string GetLastName() => _lastName;

    public void SetLastName(string lastName) => _lastName = lastName;

    public string GetAddress() => _address;

    public void SetAddress(string address) => _address = address;

    public DateTime? GetDateOfBirthday() => _dateOfBirthday;

    public void SetDateOfBirthday(DateTime? dateOfBirthday) => _dateOfBirthday = dateOfBirthday;

    public Account GetAccount() => _account;
}