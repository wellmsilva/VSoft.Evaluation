using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Users.LoginUserUseCase;

public interface ILoginUserCommandHandler : ICommandHandler<LoginUserCommand, LoginUserResponse?>
{
}
