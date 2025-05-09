using System.Security.Cryptography;

namespace VSoft.Evaluation.Domain.ValueObjects;

public record Password
{
    private readonly string _cypherkey = "vsoft-evaluation-cypherkey-value";
    public string? Value { get; }

    public Password(string? value)
    {
        Value = generateHash(value);
    }

    public static implicit operator Password?(string? value) => new Password(value);

    public static implicit operator string?(Password value) => value?.Value;  

    private string? generateHash(string? value)
    {
        if (string.IsNullOrEmpty(value)) return null;

        var encoding = new System.Text.ASCIIEncoding();

        var messageBytes = encoding.GetBytes(value);
        var keyBytes = encoding.GetBytes(_cypherkey);

        using var hmacsha256 = new HMACSHA256(keyBytes);
        var hashmessage = hmacsha256.ComputeHash(messageBytes);
        return Convert.ToBase64String(hashmessage);
    }
}
