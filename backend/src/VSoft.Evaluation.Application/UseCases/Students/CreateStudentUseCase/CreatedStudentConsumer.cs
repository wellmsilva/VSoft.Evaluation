using MassTransit;
using Microsoft.Extensions.Logging;
using VSoft.Evaluation.Domain.Entities;
using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.UseCases.Students.CreateStudentUseCase;

internal sealed class CreatedStudentConsumer : IConsumer<CreateStudentCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<CreatedStudentConsumer> _logger;

    public CreatedStudentConsumer(ILogger<CreatedStudentConsumer> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public async Task Consume(ConsumeContext<CreateStudentCommand> context)
    {
        _logger.LogInformation("CreatedStudent Name: {Name}", context.Message.Name);

        if (await _userRepository.Exists(context.Message.Cpf))
            return;

        User user = new(context.Message.Name, context.Message.Cpf, context.Message.Cpf, context.Message.Cpf, Domain.Enums.UserRole.Student);
        User entity = await _userRepository.CreateAsync(user);

        _logger.LogInformation("User Name: {Name} created", context.Message.Name);

    }
}
