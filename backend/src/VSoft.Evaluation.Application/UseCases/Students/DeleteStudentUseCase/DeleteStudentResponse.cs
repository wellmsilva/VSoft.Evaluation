using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Application.UseCases.Students.DeleteStudentUseCase;

public record DeleteStudentResponse(Guid Id) : IResponse
{
    public static implicit operator DeleteStudentResponse(Student student)
        => new DeleteStudentResponse(student.Id);
}
