using VSoft.Evaluation.Domain.Entities;

namespace VSoft.Evaluation.Domain.Repositories;

public interface IStudentRepository
{
    Task<Student?> CreateAsync(Student student, CancellationToken cancellationToken);
    Task<bool> Delete(Student student, CancellationToken cancellationToken);
    IEnumerable<Student> GetAll(string? query);
    Task<Student?> GetByCpf(string cpf, CancellationToken cancellationToken);
    Task<Student?> GetById(Guid id, CancellationToken cancellationToken);
}
