using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Students.DeleteStudentUseCase;

public record DeleteStudentCommand(Guid Id): ICommand
{
}
