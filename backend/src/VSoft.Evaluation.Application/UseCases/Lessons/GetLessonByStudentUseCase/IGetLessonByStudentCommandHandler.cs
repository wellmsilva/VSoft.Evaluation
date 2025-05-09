using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Lessons.GetLessonByStudentUseCase;

public interface IGetLessonByStudentCommandHandler: ICommandHandler<GetLessonByStudentCommand, GetLessonByStudentResponse>
{
}
