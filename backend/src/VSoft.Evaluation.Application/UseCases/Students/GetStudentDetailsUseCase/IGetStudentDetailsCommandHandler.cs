using VSoft.Evaluation.Application.Common.Interfaces;
using VSoft.Evaluation.Application.UseCases.Students.GetStudentUseCase;

namespace VSoft.Evaluation.Application.UseCases.Students.GetStudentDetailsUseCase;

public interface IGetStudentDetailsCommandHandler :ICommandHandler<GetStudentDetailsCommand, GetStudentDetailsResponse?>
{
}
