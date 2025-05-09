using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Application.UseCases.Students.CreateStudentUseCase;

public sealed record CreateStudentCommand(string Name, string Cpf, DateOnly DateBirth, string Email, string Registration) : ICommand
{
    public static implicit operator Student(CreateStudentCommand command)
        => new(
            command.Name,
            command.DateBirth,
            command.Cpf,
            command.Email,
            command.Registration
        );
}
