namespace BankProject;

public readonly record struct Name
{
    public const int MinLength = 5;
    public const int MaxLength = 32;
    private readonly string _value;

    public Name(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        var constraints = value.Length;
        _value = constraints switch
                 {
                     < MinLength => throw new ArgumentOutOfRangeException(nameof(value), $"O nome deve ter ao menos {MinLength} caracteres."),
                     > MaxLength => throw new ArgumentOutOfRangeException(nameof(value), $"O nome não deve exceder {MaxLength} caracteres."),
                     _ => value
                 };
    }

    public override string ToString() => _value;

    public static implicit operator string(Name value) => value.ToString();
}