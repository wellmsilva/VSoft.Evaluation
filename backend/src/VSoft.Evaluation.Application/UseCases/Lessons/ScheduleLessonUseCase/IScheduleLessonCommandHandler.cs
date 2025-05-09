using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Lessons.ScheduleLessonUseCase;

public interface IScheduleLessonCommandHandler : ICommandHandler<ScheduleLessonCommand, ScheduleLessonResponse?>
{
}
