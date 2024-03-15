namespace GymWatch.Infrastructure.Requests;

public record RegisterUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}