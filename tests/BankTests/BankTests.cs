namespace BankTests;

public class BankTests
{
    private static readonly Faker Faker = new(Constants.Locale);
    
    [Fact]
    public void Add_NullCustomer_ThrowsException()
    {
        // Arrange
        var bank = Fakers.Bank.Generate();

        // Act
        var act = () => bank.AddCustomer(null!);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Add_ValidCustomer_InsertsInList()
    {
        // Arrange
        var bank = Fakers.Bank.Generate();
        var customer = Fakers.Customer.Generate();

        // Act
        bank.AddCustomer(customer);

        // Assert
        bank.GetCustomerList().Should().Contain(customer);
    }

    [Fact]
    public void GetCustomer_WithValidPosition_ReturnsCustomer()
    {
        // Arrange
        var bank = Fakers.Bank.Generate();
        const int position = 5;
        Enumerable.Range(0, position)
                  .ToList()
                  .ForEach(_ => bank.AddCustomer(Fakers.Customer.Generate()));
        var customer = Fakers.Customer.Generate();
        bank.AddCustomer(customer);

        // Act
        var sut = bank.GetCustomer(position);

        // Assert
        sut.Should().BeSameAs(customer);
    }

    [Fact]
    public void GetCustomer_WithInvalidPosition_ThrowsException()
    {
        // Arrange
        var bank = Fakers.Bank.Generate();
        const int position = 5;
        Enumerable.Range(0, position)
                  .ToList()
                  .ForEach(_ => bank.AddCustomer(Fakers.Customer.Generate()));

        // Act
        var act = () => bank.GetCustomer(Faker.Random.Int(position));

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}

public class NameTests
{
    private static readonly Faker Faker = new(Constants.Locale);

    [Fact]
    public void Create_WithValidNames_ReturnsInstance()
    {
        // Arrange
        var name = Faker.Random.String(Name.MinLength, Name.MaxLength);

        // Act
        var sut = new Name(name);

        // Assert
        sut.Should().NotBeNull();
    }
    
    [Fact]
    public void ToString_Returns_Name()
    {
        // Arrange
        var expected = Faker.Random.String(Name.MinLength, Name.MaxLength);

        // Act
        var sut = new Name(expected).ToString();

        // Assert
        sut.Should().BeEquivalentTo(expected);
    }
}