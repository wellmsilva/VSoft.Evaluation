using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Users.LoginUserUseCase;

public record LoginUserResponse(string Token, string Name, string Role) : IResponse
{
}
