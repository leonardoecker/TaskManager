using TaskManager.Communication.Responses;
using TaskManager.Entity.Repositories;

namespace TaskManager.Application.UseCases.List;

public class ListTasksUseCase
{
    private readonly ITaskRepository taskRepository = new TaskRepository();

    public ResponseListTasksJson Execute()
    {

        var tasks = taskRepository.GetAll();
        var response = tasks.Select(task => new ResponseTaskJson
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            DueDate = task.DueDate,
            Priority = (Communication.Enums.Priority)task.Priority,
            Status = (Communication.Enums.Status)task.Status
        }).ToList();

        return new ResponseListTasksJson
        {
            Tasks = response
        };
        ;
    }
}