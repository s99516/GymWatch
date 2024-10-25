using GymWatch.Core.Domain.Abstraction;
using GymWatch.Core.Domain.Enums;

namespace GymWatch.Core.Domain.Models;

public class Log : IModel
{
    public int Id { get; set; }
    public string Message { get; set; }
    public Severity Severity { get; set; }
    public DateTime Date { get; set; }

    public Log(string message, Severity severity)
    {
        SetMessage(message);
        Severity = severity;
        Date = DateTime.UtcNow;
    }

    private void SetMessage(string message)
    {
        if (string.IsNullOrEmpty(message)) throw new ArgumentNullException("Message cannot be null");
        Message = message;
    }
}