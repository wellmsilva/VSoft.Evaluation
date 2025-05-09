namespace VSoft.Evaluation.Domain.ValueObjects;

public record Cpf
{
    public string? Value { get; }
    public Cpf(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return;
        if (value.Length != 11) throw new ArgumentNullException(nameof(value));

        Value = value;
    }

    public static implicit operator Cpf(string value) => new (value);
    public static implicit operator string?(Cpf value) => value?.Value;
}
