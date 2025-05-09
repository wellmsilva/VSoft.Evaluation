using VSoft.Evaluation.Domain.Enums;

namespace VSoft.Evaluation.Domain.Entities;

public class User
{

    protected User() { }
    public User(string name, string cpf, string userName, string password, UserRole userRole) : this()
    {
        Id = Guid.NewGuid();
        Name = name;
        Cpf = cpf;
        UserName = userName;
        Password = password;
        Role = userRole;
    }

    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string UserName { get; init; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.Student;
}
