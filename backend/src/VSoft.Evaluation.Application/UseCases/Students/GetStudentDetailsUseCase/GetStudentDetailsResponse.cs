using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentUseCase;

public record GetStudentDetailsResponse(Guid Id, string Name, string Cpf, string Email, DateOnly DateBirth, string Registration, bool CanLessonsPractical, int Progress) : IResponse
{
    public static implicit operator GetStudentDetailsResponse?(Student? student) => student == null ? null : new GetStudentDetailsResponse(
        student.Id, student.Name, student.Cpf, student.Email, student.DateBirth, student.Registration, student.CanLessonsPractical, student.Progress
    );
}
