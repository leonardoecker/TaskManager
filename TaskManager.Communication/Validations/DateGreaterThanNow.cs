using System.ComponentModel.DataAnnotations;

namespace TaskManager.Communication.Validations;

[AttributeUsage(AttributeTargets.Property |
  AttributeTargets.Field, AllowMultiple = false)]
internal class DateCreaterThanNow : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null) return true;

        if (value is DateTime date) return date.Date > DateTime.Today;

        return false;
    }
}