using Microsoft.Extensions.Logging;
using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.UseCases.Students.DeleteStudentUseCase;

internal sealed class DeleteStudentCommandHandler : IDeleteStudentCommandHandler
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<DeleteStudentCommandHandler> _logger;

    public DeleteStudentCommandHandler(IStudentRepository studentRepository, ILogger<DeleteStudentCommandHandler> logger)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }


    public async Task<DeleteStudentResponse> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        var entity = await _studentRepository.GetById(command.Id, cancellationToken);
        if (entity == null)
        {
            _logger.LogWarning("Not Found");
            throw new ArgumentNullException(nameof(command.Id));
        }

        await _studentRepository.Delete(entity, cancellationToken);
        _logger.LogInformation("Student {Id} deleted", command.Id);
        return entity;
    }
}
