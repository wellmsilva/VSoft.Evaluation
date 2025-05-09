using FluentValidation;

namespace VSoft.Evaluation.WebApi.Features.Students.CreateStudent;

public class CreateStudentRequestValidator : AbstractValidator<CreateStudentRequest>
{
    public CreateStudentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Cpf)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Cpf)
          .Must(x => x.Length == 11)
          .WithMessage("Invalid value");

        RuleFor(x => x.Email)
          .NotEmpty()
          .NotNull();

        RuleFor(x => x.Email)
           .EmailAddress()
           .WithMessage("Invalid value");

        RuleFor(x => x.DateBirth)
          .NotEmpty()
          .NotNull();

        RuleFor(x => x.registration)
          .NotEmpty()
          .NotNull();
    }
}
