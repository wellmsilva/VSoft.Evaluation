using VSoft.Evaluation.Application.UseCases.Students.DeleteStudentUseCase;

namespace VSoft.Evaluation.WebApi.Features.Students.DeleteStudent;

public record DeleteStudentRequest(Guid Id)
{
    public static implicit operator DeleteStudentCommand(DeleteStudentRequest request)
        => new DeleteStudentCommand(request.Id);
}
