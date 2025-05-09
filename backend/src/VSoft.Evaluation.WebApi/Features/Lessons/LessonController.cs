using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VSoft.Evaluation.Application.UseCases.Lessons.ConcludeLessonUseCase;
using VSoft.Evaluation.Application.UseCases.Lessons.GetLessonByStudentUseCase;
using VSoft.Evaluation.Application.UseCases.Lessons.ScheduleLessonUseCase;
using VSoft.Evaluation.WebApi.Commons;
using VSoft.Evaluation.WebApi.Features.Lessons.ConcludeLesson;
using VSoft.Evaluation.WebApi.Features.Lessons.GetLessonByStudent;
using VSoft.Evaluation.WebApi.Features.Lessons.ScheduleLesson;

namespace VSoft.Evaluation.WebApi.Features.Lessons;


[ApiController]
[Route("Lesson")]
public class LessonController : CommonController
{

    [HttpPost("schedule")]
    [Authorize(Roles = "CFC")]
    public async Task<IActionResult> Schedule(
        [FromBody] ScheduleLessonRequest request,
        [FromServices] IScheduleLessonCommandHandler handler,
        CancellationToken cancellationToken
        )
    {

        var validator = new ScheduleLessonRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await handler.Handle(request, cancellationToken);

        return Created(string.Empty, response);
    }

    [HttpGet("student/{id:guid}")]
    [Authorize(Roles = "CFC, Student")]
    public async Task<IActionResult> GetLessonByStudent(Guid id,
        [FromServices] IGetLessonByStudentCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var response = await handler.Handle(new GetLessonByStudentCommand(id), cancellationToken);
        return Ok(response);
    }



    [HttpPut("conclude")]
    [Authorize(Roles = "CFC")]
    public async Task<IActionResult> Conclude(
        [FromBody] ConcludeLessonRequest request,
        [FromServices] IConcludeLessonCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var response = await handler.Handle(request, cancellationToken);
        return Ok(response);
    }
}
