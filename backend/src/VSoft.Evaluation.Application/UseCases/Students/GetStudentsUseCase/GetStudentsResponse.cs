using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentsUseCase;

public record GetStudentsResponse : IResponse
{

    public IEnumerable<GetStudentsItemResponse> Items { get; set; } = [];
    public int Total { get; set; }
}


public record GetStudentsItemResponse(Guid Id, string Name, string Cpf, string Email, DateOnly DateBirth, string Registration, int Progress, bool CanLessonsPractical)
{

    public static implicit operator GetStudentsItemResponse(Student student) => new GetStudentsItemResponse(
        student.Id, student.Name, student.Cpf, student.Email, student.DateBirth, student.Registration, student.Progress, student.CanLessonsPractical
    );
};