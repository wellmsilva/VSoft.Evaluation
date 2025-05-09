using Microsoft.EntityFrameworkCore;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.Repositories;
using VSoft.Evaluation.Infrastructure.Contexts;

namespace VSoft.Evaluation.Infrastructure.Repositories;

internal class UserRepository :RepositoryBase, IUserRepository
{
    public UserRepository(DefaultContext context) : base(context) { }

    public async Task<User?> GetByUserName(string userName, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName,cancellationToken);
    }
}
