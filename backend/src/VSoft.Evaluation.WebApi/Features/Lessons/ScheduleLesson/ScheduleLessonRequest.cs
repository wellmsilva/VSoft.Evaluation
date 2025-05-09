using VSoft.Evaluation.Application.UseCases.Lessons.ScheduleLessonUseCase;

namespace VSoft.Evaluation.WebApi.Features.Lessons.ScheduleLesson;

public record ScheduleLessonRequest(Guid StudentId,int Number, DateOnly Date,TimeOnly Hour)
{
    public static implicit operator ScheduleLessonCommand(ScheduleLessonRequest request)
        => new ScheduleLessonCommand(request.StudentId, request.Number, request.Date, request.Hour);
}
