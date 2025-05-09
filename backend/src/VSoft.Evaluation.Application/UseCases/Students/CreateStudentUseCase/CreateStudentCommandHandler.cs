using MassTransit;
using Microsoft.Extensions.Logging;
using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.UseCases.Students.CreateStudentUseCase;

internal sealed class CreateStudentCommandHandler : ICreateStudentCommandHandler
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<CreateStudentCommandHandler> _logger;
    private readonly IBus _bus;

    public CreateStudentCommandHandler(IStudentRepository studentRepository, ILogger<CreateStudentCommandHandler> logger, IBus bus)
    {
        _logger = logger;
        _studentRepository = studentRepository;
        _bus = bus;
    }

    public async Task<CreateStudentResponse?> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var entity = await _studentRepository.CreateAsync(command, cancellationToken);
        if (entity != null)
        {
            _logger.LogInformation("Student Created");
            await _bus.Publish(command);
        }
        return entity;
    }
}
