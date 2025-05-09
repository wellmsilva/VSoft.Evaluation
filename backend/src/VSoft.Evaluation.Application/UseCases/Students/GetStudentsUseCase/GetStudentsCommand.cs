using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentsUseCase;

public record GetStudentsCommand(string? Query) : ICommand
{

}
