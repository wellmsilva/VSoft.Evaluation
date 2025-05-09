using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Application.UseCases.Lessons.ScheduleLessonUseCase;

public record ScheduleLessonResponse(Guid Id, Guid StudentId, int Numero, DateOnly Date, TimeOnly Hour, bool Concluded) : IResponse
{
    public static implicit operator ScheduleLessonResponse(Lesson lesson)
        => new ScheduleLessonResponse(lesson.Id, lesson.StudentId, lesson.Number, lesson.Date, lesson.Hour, lesson.Concluded);
}
