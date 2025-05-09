using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Application.UseCases.Lessons.ConcludeLessonUseCase;

public record ConcludeLessonResponse(Guid Id, Guid StudentId, int Number, DateOnly Date, TimeOnly Hour) : IResponse
{
    public static implicit operator ConcludeLessonResponse(Lesson lesson)
        => new ConcludeLessonResponse(lesson.Id, lesson.StudentId, lesson.Number, lesson.Date, lesson.Hour);
}
