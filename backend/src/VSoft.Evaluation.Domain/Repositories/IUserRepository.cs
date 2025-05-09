

using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Domain.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<bool> Exists(string cpf, CancellationToken cancellationToken = default);
    Task<User?> GetByUserName(string userName, CancellationToken cancellationToken = default);
}
