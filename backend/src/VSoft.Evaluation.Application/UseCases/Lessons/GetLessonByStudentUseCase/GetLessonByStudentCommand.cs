using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Lessons.GetLessonByStudentUseCase;

public record GetLessonByStudentCommand(Guid Id) :ICommand
{

}
