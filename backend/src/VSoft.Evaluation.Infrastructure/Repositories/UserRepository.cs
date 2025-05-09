using Microsoft.EntityFrameworkCore;
using System.Threading;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.Repositories;
using VSoft.Evaluation.Infrastructure.Contexts;

namespace VSoft.Evaluation.Infrastructure.Repositories;

internal class UserRepository :RepositoryBase, IUserRepository
{
    public UserRepository(DefaultContext context) : base(context) { }

    public async Task<User> CreateAsync(User user)
    {
        var entityEntry = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;

    }

    public async Task<bool> Exists(string cpf, CancellationToken cancellationToken)
    {
        return await _context.Users.AnyAsync(x => x.Cpf == cpf, cancellationToken);
    }

    public async Task<User?> GetByUserName(string userName, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName,cancellationToken);
    }
}
