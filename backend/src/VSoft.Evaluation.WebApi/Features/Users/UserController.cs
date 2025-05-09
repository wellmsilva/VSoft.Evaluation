using Microsoft.AspNetCore.Mvc;
using VSoft.Evaluation.Application.UseCases.Users.LoginUserUseCase;
using VSoft.Evaluation.WebApi.Commons;
using VSoft.Evaluation.WebApi.Features.Users.LoginUser;

namespace VSoft.Evaluation.WebApi.Features.Users;

[ApiController]
[Route("User")]
public class UserController : CommonController
{
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login(
        [FromBody]LoginUserRequest request,
        [FromServices] ILoginUserCommandHandler handler,
        CancellationToken cancellationToken
        )
    {
        var response = await handler.Handle(request, cancellationToken);
        if(response == null)
        {
            return NotFound("Usuário não encontrado");
        }

        return Ok(response);
    }
}
