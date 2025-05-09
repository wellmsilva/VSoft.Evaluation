using VSoft.Evaluation.Application.UseCases.Students.GetStudentUseCase;
using VSoft.Evaluation.Domain.Repositories;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentDetailsUseCase;

internal sealed  class GetStudentDetailsCommandHandler : IGetStudentDetailsCommandHandler
{

    private readonly IStudentRepository _studentRepository;

    public GetStudentDetailsCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;

    }

    public async Task<GetStudentDetailsResponse?> Handle(GetStudentDetailsCommand command, CancellationToken cancellationToken = default)
    {
        var entity = await _studentRepository.GetByCpf(command.Cpf, cancellationToken);
        return entity;
    }
}
