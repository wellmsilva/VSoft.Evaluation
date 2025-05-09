using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentUseCase;

public interface IGetStudentCommandHandler : ICommandHandler<GetStudentCommand, GetStudentResponse?>
{
}
