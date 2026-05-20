using TaskManager.Entity.Models;

namespace TaskManager.Entity.Repositories;

public interface ITaskRepository
{
    List<TaskItem> GetAll();
    TaskItem? GetById(Guid id);
    void Update(Guid id, TaskItem task);
    void Create(TaskItem task);
    void Delete(Guid id);
}