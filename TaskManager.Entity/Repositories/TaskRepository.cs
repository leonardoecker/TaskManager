using System.Text.Json;
using TaskManager.Entity.Models;

namespace TaskManager.Entity.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly string _filePath = "tasks.json";
    private readonly JsonSerializerOptions _options;

    public TaskRepository()
    {
        _options = new JsonSerializerOptions { WriteIndented = true };

        InitializeFile();
    }

    private void InitializeFile()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
    }
    public void Create(TaskItem task)
    {
        var tasks = GetAll();
        tasks.Add(task);

        var newJson = JsonSerializer.Serialize(tasks, _options);
        File.WriteAllText(_filePath, newJson);
    }

    public void Delete(Guid id)
    {
        var tasks = GetAll();
        var taskToRemove = tasks.FirstOrDefault(t => t.Id.Equals(id));

        if (taskToRemove != null)
        {
            tasks.Remove(taskToRemove);

            var newJson = JsonSerializer.Serialize(tasks, _options);
            File.WriteAllText(_filePath, newJson);
        }
    }

    public List<TaskItem> GetAll()
    {
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? [];
    }

    public TaskItem? GetById(Guid id)
    {
        var tasks = GetAll();
        return tasks.FirstOrDefault(b => b.Id.Equals(id));
    }

    public void Update(Guid id, TaskItem task)
    {
        var tasks = GetAll();
        var existingTask = tasks.FirstOrDefault(t => t.Id.Equals(id));

        if (existingTask != null)
        {
            existingTask.Description = task.Description;
            existingTask.Name = task.Name;
            existingTask.Priority = task.Priority;
            existingTask.Status = task.Status;
            existingTask.DueDate = task.DueDate;
            existingTask.UpdatedAt = DateTime.Now;

            var newJson = JsonSerializer.Serialize(tasks, _options);
            File.WriteAllText(_filePath, newJson);
        }
    }
}