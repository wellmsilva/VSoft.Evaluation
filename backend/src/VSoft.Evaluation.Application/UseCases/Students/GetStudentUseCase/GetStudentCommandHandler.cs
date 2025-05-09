using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentUseCase;

internal sealed class GetStudentCommandHandler : IGetStudentCommandHandler
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;

    }

    public async Task<GetStudentResponse?> Handle(GetStudentCommand command, CancellationToken cancellationToken)
    {
        var entity = await _studentRepository.GetById(command.Id, cancellationToken);

        return  (GetStudentResponse?)entity;
    }
}
