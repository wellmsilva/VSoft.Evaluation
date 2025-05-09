using VSoft.Evaluation.Application.Common.Interfaces;

namespace VSoft.Evaluation.Application.UseCases.Students.DeleteStudentUseCase;

public interface IDeleteStudentCommandHandler :ICommandHandler<DeleteStudentCommand, DeleteStudentResponse>
{
}
