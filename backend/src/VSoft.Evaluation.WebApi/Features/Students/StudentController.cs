using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VSoft.Evaluation.Application.UseCases.Students.CreateStudentUseCase;
using VSoft.Evaluation.Application.UseCases.Students.DeleteStudentUseCase;
using VSoft.Evaluation.Application.UseCases.Students.GetStudentDetailsUseCase;
using VSoft.Evaluation.Application.UseCases.Students.GetStudentsUseCase;
using VSoft.Evaluation.Application.UseCases.Students.GetStudentUseCase;
using VSoft.Evaluation.WebApi.Commons;
using VSoft.Evaluation.WebApi.Features.Students.CreateStudent;
using VSoft.Evaluation.WebApi.Features.Students.DeleteStudent;
using VSoft.Evaluation.WebApi.Features.Students.GetStudent;
using VSoft.Evaluation.WebApi.Features.Students.GetStudents;

namespace VSoft.Evaluation.WebApi.Features.Students;


[ApiController]
[Route("Student")]
public class StudentController : CommonController
{
    /// <summary>
    /// Create a student
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "CFC")]
    [ProducesResponseType(typeof(CreateStudent.CreateStudentResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastro(
        [FromBody] CreateStudentRequest request,
        [FromServices] ICreateStudentCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var validator = new CreateStudentRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await handler.Handle(request, cancellationToken);
        return Created(string.Empty, response);
    }

    /// <summary>
    /// Get all Students.
    /// </summary>
    /// <param name="registration"></param>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Roles = "CFC")]
    [ProducesResponseType(typeof(GetStudents.GetStudentsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStudents(
        [FromQuery] GetStudentsRequest request,
        [FromServices] IGetStudentsCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var validator = new GetStudentsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await handler.Handle(request, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Get a specific Student.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "CFC")]
    [ProducesResponseType(typeof(GetStudent.GetStudentResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStudent(
        [FromRoute] GetStudentRequest request,
        [FromServices] IGetStudentCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var validator = new GetStudentRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await handler.Handle(request, cancellationToken);

        return Ok((GetStudent.GetStudentResponse?)response);
    }

    /// <summary>
    /// Get a specific Student.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize(Roles = "Student")]
    [HttpGet("details")]
    [ProducesResponseType(typeof(GetStudentDetailsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStudentDetails(
         [FromQuery] string cpf,
         [FromServices] IGetStudentDetailsCommandHandler handler,
         CancellationToken cancellationToken)
    {
        var response = await handler.Handle(cpf, cancellationToken);
        return Ok(response);
    }


    /// <summary>
    /// Delete a specific Student.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "CFC")]
    [ProducesResponseType(typeof(DeleteStudent.DeleteStudentResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteStudent(
        [FromRoute] DeleteStudentRequest request,
          [FromServices] IDeleteStudentCommandHandler handler,
        CancellationToken cancellationToken
        )
    {
        var validator = new DeleteStudentRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await handler.Handle(request, cancellationToken);

        return Ok((DeleteStudent.DeleteStudentResponse?)response);
    }
}
