using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Domain.Repositories;

public interface ILessonRepository
{
    Task<Lesson> CreateAsync(Lesson lesson, CancellationToken cancellationToken);
    Task<Lesson> UpdateAsync(Lesson lesson, CancellationToken cancellationToken);
    Lesson? GetById(Guid id);
    IEnumerable<Lesson> GetLessonByStudent(Guid studentId);
    
}
