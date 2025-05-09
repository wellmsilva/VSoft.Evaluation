using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Lessons.ConcludeLessonUseCase;

public record ConcludeLessonCommand(Guid Id) :ICommand
{
}
