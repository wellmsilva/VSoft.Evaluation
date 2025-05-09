

using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByUserName(string userName, CancellationToken cancellationToken);
}
