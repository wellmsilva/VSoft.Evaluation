using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentUseCase;

public record GetStudentResponse(Guid Id, string Name, string Cpf, string Email, DateOnly DateBirth, string Registration) : IResponse
{
    public static implicit operator GetStudentResponse?(Student? student) => student == null ? null : new GetStudentResponse(
        student.Id, student.Name, student.Cpf, student.Email, student.DateBirth, student.Registration
    );
}
