using TaskManager.Entity.Repositories;

namespace TaskManager.Application.UseCases.Delete;

public class DeleteTaskUseCase
{
    private readonly ITaskRepository taskRepository = new TaskRepository();

    public bool Execute(Guid id)
    {

        var task = taskRepository.GetById(id);

        if (task is null)
        {
            return false;
        }

        taskRepository.Delete(id);

        return true;
    }
}