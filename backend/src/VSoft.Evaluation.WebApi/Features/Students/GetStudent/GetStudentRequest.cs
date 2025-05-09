using VSoft.Evaluation.Application.UseCases.Students.GetStudentUseCase;

namespace VSoft.Evaluation.WebApi.Features.Students.GetStudent;

public record GetStudentRequest(Guid Id)
{
    public static implicit operator GetStudentCommand(GetStudentRequest request)
        => new GetStudentCommand(request.Id);
}
