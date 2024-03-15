namespace GymWatch.Infrastructure.Commands;

public class LoginCommand
{
    public Guid? TokenId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

