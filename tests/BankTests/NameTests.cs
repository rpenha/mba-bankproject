namespace BankTests;

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

    [Fact]
    public void Create_WithInvalidMinLength_ThrowsArgumentException()
    {
        // Arrange
        var name = Faker.Random.String(0, Name.MinLength);

        // Act
        var act = () => new Name(name);

        // Assert
        act.Should()
           .ThrowExactly<ArgumentOutOfRangeException>()
           .And.Message.Should()
           .Contain($"O nome deve ter ao menos {Name.MinLength} caracteres.");
    }

    [Fact]
    public void Create_WithInvalidMaxLength_ThrowsArgumentException()
    {
        // Arrange
        var name = Faker.Random.String(Name.MaxLength, Name.MaxLength + 10);

        // Act
        var act = () => new Name(name);

        // Assert
        act.Should()
           .ThrowExactly<ArgumentOutOfRangeException>()
           .And.Message.Should()
           .Contain($"O nome não deve exceder {Name.MaxLength} caracteres.");
    }
}