using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentUseCase;

public record GetStudentCommand(Guid Id) : ICommand
{
}
