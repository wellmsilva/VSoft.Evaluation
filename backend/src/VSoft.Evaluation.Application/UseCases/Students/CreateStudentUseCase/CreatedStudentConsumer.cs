using MassTransit;
using Microsoft.Extensions.Logging;

namespace VSoft.Evaluation.Application.UseCases.Students.CreateStudentUseCase;

public class CreatedStudentConsumer : IConsumer<CreateStudentCommand>
{
    private readonly ILogger<CreatedStudentConsumer> _logger;

    public CreatedStudentConsumer(ILogger<CreatedStudentConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<CreateStudentCommand> context)
    {
        _logger.LogInformation("CreatedStudent Name: {Name}", context.Message.Name);
    }
}
