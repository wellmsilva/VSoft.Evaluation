using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace VSoft.Evaluation.WebApi.Commons;

public class CommonController : ControllerBase
{
    protected Guid? UserId
    {
        get
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity?.FindFirst(ClaimTypes.Sid)?.Value;
            return !string.IsNullOrEmpty(userId) ? Guid.Parse(userId!) : null;
        }
    }
}
