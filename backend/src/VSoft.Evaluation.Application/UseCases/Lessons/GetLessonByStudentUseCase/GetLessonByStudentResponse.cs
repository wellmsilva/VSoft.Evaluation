using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Application.UseCases.Lessons.GetLessonByStudentUseCase;




public record GetLessonByStudentResponse(IEnumerable<GetLessonByStudentItemResponse> Items):IResponse
{  
}

public record GetLessonByStudentItemResponse(Guid Id, Guid StudentId, int Number, DateOnly Date, TimeOnly Hour, bool Concluded) 
{
    public static implicit operator GetLessonByStudentItemResponse(Lesson lesson)
        => new GetLessonByStudentItemResponse(lesson.Id, lesson.StudentId, lesson.Number, lesson.Date, lesson.Hour, lesson.Concluded);
}
