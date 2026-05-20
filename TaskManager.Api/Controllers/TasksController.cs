using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Create;
using TaskManager.Application.UseCases.Delete;
using TaskManager.Application.UseCases.GetById;
using TaskManager.Application.UseCases.List;
using TaskManager.Application.UseCases.Update;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Api.Controllers.Tasks;

[ApiController]
[Route("/[controller]")]
public class TasksController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetTaskByIdUseCase();
        ResponseTaskJson? response = useCase.Execute(id);

        if (response == null)
        {
            return NotFound("Task não encontrada");
        }

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseListTasksJson), StatusCodes.Status201Created)]
    public IActionResult List()
    {
        var useCase = new ListTasksUseCase();
        ResponseListTasksJson? response = useCase.Execute();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestTaskJson request)
    {
        var useCase = new CreateTaskUseCase();
        useCase.Execute(request);

        return Created(string.Empty, "Tarefa criada com sucesso");
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestTaskJson request)
    {
        var useCase = new UpdateTaskUseCase();
        var response = useCase.Execute(id, request);

        if (response == false)
        {
            return NotFound("Task não encontrada");
        }

        return Ok("Tarefa atualizada com sucesso");
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteTaskUseCase();
        var response = useCase.Execute(id);

        if (response == false)
        {
            return NotFound("Task não encontrada");
        }

        return NoContent();
    }
}