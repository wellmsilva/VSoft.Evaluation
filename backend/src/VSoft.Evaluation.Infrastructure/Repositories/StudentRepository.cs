using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.Repositories;
using VSoft.Evaluation.Domain.ValueObjects;
using VSoft.Evaluation.Infrastructure.Contexts;

namespace VSoft.Evaluation.Infrastructure.Repositories;

internal sealed class StudentRepository : RepositoryBase, IStudentRepository
{
    public StudentRepository(DefaultContext context) : base(context) { }

    public async Task<Student?> CreateAsync(Student student, CancellationToken cancellationToken)
    {
        var result = await _context.AddAsync(student, cancellationToken);
        var res = await _context.SaveChangesAsync(cancellationToken) > 0;
        return res ? result.Entity : null;
    }

    public async Task<bool> Delete(Student student, CancellationToken cancellationToken)
    {
        _context.Students.Remove(student);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    public IEnumerable<Student> GetAll(string? query)
    {
        Expression<Func<Student, bool>> predicate = x => x.Cpf == query || x.Registration == query;

        return _context.Students
            .Include(x => x.Lessons)
            .Where(string.IsNullOrEmpty(query) ? x => true : predicate)
            .AsNoTracking();
    }

    public async Task<Student?> GetByCpf(string cpf, CancellationToken cancellationToken)
    {

        return await _context.Students
            .Include(x => x.Lessons)
            .FirstOrDefaultAsync(c => c.Cpf == cpf, cancellationToken);
    }

    public async Task<Student?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Students
            .Include(x => x.Lessons)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
