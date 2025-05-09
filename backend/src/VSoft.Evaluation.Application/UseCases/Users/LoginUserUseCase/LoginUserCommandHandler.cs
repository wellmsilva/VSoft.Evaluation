using VSoft.Evaluation.Application.UseCases.Users.Providers;
using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.UseCases.Users.LoginUserUseCase;

internal sealed class LoginUserCommandHandler : ILoginUserCommandHandler
{
    private readonly TokenProvider _tokenProvider;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IUserRepository userRepository, TokenProvider tokenProvider)
    {
        _userRepository = userRepository;
        _tokenProvider = tokenProvider;
    }

    public async Task<LoginUserResponse?> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUserName(command.UserName, cancellationToken);
        if (user == null)
        {
            return null;
        }

        var token = _tokenProvider.Create(user!);

        return new LoginUserResponse(token, user.Name, user.Role.ToString());
    }
}
