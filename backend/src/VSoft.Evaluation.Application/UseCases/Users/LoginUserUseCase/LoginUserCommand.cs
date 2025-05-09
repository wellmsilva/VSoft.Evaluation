using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Users.LoginUserUseCase;

public record LoginUserCommand(string UserName, string Password): ICommand
{
}
