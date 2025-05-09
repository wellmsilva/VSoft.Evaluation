
using Microsoft.EntityFrameworkCore;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.Repositories;
using VSoft.Evaluation.Infrastructure.Contexts;

namespace VSoft.Evaluation.Infrastructure.Repositories;

internal class LessonRepository : RepositoryBase, ILessonRepository
{
    public LessonRepository(DefaultContext context) : base(context) { }

    public async Task<Lesson> CreateAsync(Lesson lesson, CancellationToken cancellationToken)
    {
        await _context.AddAsync(lesson, cancellationToken);
        await _context.SaveChangesAsync();
        return lesson;
    }

    public Lesson? GetById(Guid id)
    {
        return  _context.Lessons.Include(x => x.Student).FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Lesson> GetLessonByStudent(Guid studentId)
    {
        return _context.Lessons.Where(x => x.StudentId == studentId).AsNoTracking();
    }

    public async Task<Lesson> UpdateAsync(Lesson lesson, CancellationToken cancellationToken)
    {
        var entityEntry =  _context.Lessons.Attach(lesson);
        await _context.SaveChangesAsync(cancellationToken);
        return entityEntry.Entity;
    }
}
