using Microsoft.Extensions.Logging;
using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentsUseCase;

internal sealed class GetStudentsCommandHandler : IGetStudentsCommandHandler
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<GetStudentsCommandHandler> _logger;


    public GetStudentsCommandHandler(IStudentRepository studentRepository, ILogger<GetStudentsCommandHandler> logger)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }

    public Task<GetStudentsResponse> Handle(GetStudentsCommand command, CancellationToken cancellationToken)
    {
        var entities = _studentRepository.GetAll(command.Query)
            .Select(x => (GetStudentsItemResponse)x).ToList() ;

        return Task.FromResult(new GetStudentsResponse { Items = entities });
    }
}
