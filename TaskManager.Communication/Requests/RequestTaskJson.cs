using System.ComponentModel.DataAnnotations;
using TaskManager.Communication.Enums;
using TaskManager.Communication.Validations;

namespace TaskManager.Communication.Requests;

public class RequestTaskJson
{
    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome deve conter entre 1 e 100 caracteres")]
    public required string Name { get; set; }

    public string? Description { get; set; }

    [EnumDataType(typeof(Priority), ErrorMessage = "O valor da prioridade é inválido")]
    public Priority Priority { get; set; }

    [EnumDataType(typeof(Status), ErrorMessage = "O valor do Status é inválido")]
    public Status Status { get; set; }

    [Required]
    [DateCreaterThanNow(ErrorMessage = "A data de vencimento precisa ser maior que agora")]
    public DateTime DueDate { get; set; }
}