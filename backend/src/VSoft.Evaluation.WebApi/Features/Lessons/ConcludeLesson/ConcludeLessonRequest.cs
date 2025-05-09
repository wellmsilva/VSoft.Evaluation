using VSoft.Evaluation.Application.UseCases.Lessons.ConcludeLessonUseCase;

namespace VSoft.Evaluation.WebApi.Features.Lessons.ConcludeLesson;

public record ConcludeLessonRequest(Guid Id)
{
    public static implicit operator ConcludeLessonCommand(ConcludeLessonRequest request)
        => new ConcludeLessonCommand(request.Id);
}
