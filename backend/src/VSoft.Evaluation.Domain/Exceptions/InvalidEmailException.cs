namespace VSoft.Evaluation.Domain.Exceptions;

internal class InvalidEmailException : Exception
{
    public InvalidEmailException(): base("Invalid email address")
    {
        
    }
}
