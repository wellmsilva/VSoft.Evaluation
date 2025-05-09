using VSoft.Evaluation.Application.UseCases.Students.CreateStudentUseCase;

namespace VSoft.Evaluation.WebApi.Features.Students.CreateStudent;

public record CreateStudentRequest(string Name, string Cpf, DateOnly DateBirth, string Email, string registration)
{
    public static implicit operator CreateStudentCommand(CreateStudentRequest request)
        => new(
           request.Name,
           request.Cpf,
           request.DateBirth,
           request.Email,
           request.registration);
}
