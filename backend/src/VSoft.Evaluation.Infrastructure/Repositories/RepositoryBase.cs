using VSoft.Evaluation.Infrastructure.Contexts;

namespace VSoft.Evaluation.Infrastructure.Repositories;

internal abstract class RepositoryBase
{
    protected readonly DefaultContext _context;

    public RepositoryBase(DefaultContext context)
    {
        _context = context;
    }
}
