using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Application.UseCases.Students.CreateStudentUseCase;

public record CreateStudentResponse(Guid Id, string Name, string Cpf, string Email, DateOnly DateBirth, string Registration) : IResponse
{
    public static implicit operator CreateStudentResponse?(Student? student)
        => student != null ? new CreateStudentResponse(student.Id, student.Name, student.Cpf, student.Email, student.DateBirth, student.Registration) : null;
}
