using VSoft.Evaluation.Application.UseCases.Students.GetStudentsUseCase;

namespace VSoft.Evaluation.WebApi.Features.Students.GetStudents;
public record GetStudentsRequest(string? Query) {

    public static implicit operator GetStudentsCommand(GetStudentsRequest request)
        => new GetStudentsCommand(request.Query);
}
