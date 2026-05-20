using System.ComponentModel;
using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Responses;

public class ResponseTaskJson
{
    [DisplayName("Identificador da task")]
    public Guid Id { get; set; }

    [DisplayName("Nome da task")]
    public required string Name { get; set; }

    [DisplayName("Descrição da task")]
    public string? Description { get; set; }

    [DisplayName("Prioridade da task")]
    public Priority Priority { get; set; }

    [DisplayName("Data de vencimento da task")]
    public DateTime DueDate { get; set; }

    [DisplayName("Status atual da task")]
    public Status Status { get; set; }

    [DisplayName("Data de criação da task")]
    public DateTime CreatedAt { get; set; }

    [DisplayName("Data da ultima atualização da task")]
    public DateTime? UpdatedAt { get; set; }

}