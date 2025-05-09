namespace VSoft.Evaluation.WebApi.Features.Lessons.ScheduleLesson;

public class ScheduleLessonResponse
{

    public static implicit operator ScheduleLessonResponse(Application.UseCases.Lessons.ScheduleLessonUseCase.ScheduleLessonResponse request)
        => new ScheduleLessonResponse();
}
