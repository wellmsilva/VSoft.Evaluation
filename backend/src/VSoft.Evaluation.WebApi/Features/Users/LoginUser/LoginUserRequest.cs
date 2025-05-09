using VSoft.Evaluation.Application.UseCases.Users.LoginUserUseCase;

namespace VSoft.Evaluation.WebApi.Features.Users.LoginUser;

public record LoginUserRequest(string UserName, string Password){
    public static implicit operator LoginUserCommand(LoginUserRequest request)
        => new LoginUserCommand(request.UserName, request.Password);
};