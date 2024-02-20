using GymWatch.Core.Domain.Abstraction;
using GymWatch.Core.Domain.Validators;

namespace GymWatch.Core.Domain.Models;

public class User : IModel<int>
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordSalt { get; set; }
    public DateTime DateCreated { get; set; }

    public ICollection<TrainingInstance> TrainingInstances { get; set; }
    public ICollection<Exercise> Exercises { get; set; }

    public User() { }

    public User(string email, string password)
    {
        SetEmail(email);
        SetPassword(password);
        DateCreated = DateTime.UtcNow;
    }

    private void SetEmail(string email)
    {
        if (!EmailAddressValidator.IsValid(email)) throw new ArgumentException("Not valid email provided");
        Email = email;
    }
    
    private void SetPassword(string password)
    {
        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("Password cannot be null");
        Password = password;
    }
}