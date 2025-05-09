using System.Text.RegularExpressions;
using VSoft.Evaluation.Domain.Exceptions;

namespace VSoft.Evaluation.Domain.ValueObjects;

public record Email
{
    public  string? Value { get; } 
    public Email(string? value)
    {
        if (string.IsNullOrEmpty(value)) return; 

        Value = value.ToLower().Trim();
        const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        if (!Regex.IsMatch(value, pattern))
            throw new InvalidEmailException();
    }

    public static implicit operator Email(string value) => new (value);
    public static implicit operator string?(Email value) => value?.Value;
}