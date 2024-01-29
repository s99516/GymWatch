using GymWatch.Core.Domain.Abstraction;

namespace GymWatch.Core.Domain.Models;

public class Exercise : IModel<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsCustom { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }

    protected Exercise() { }

    public Exercise(string name, string? description, bool isCustom)
    {
        SetName(name);
        Description = description;
        IsCustom = isCustom;
        DateCreated = DateTime.UtcNow;
    }
    
    public Exercise(string name, string? description, bool isCustom, User? user)
    {
        SetName(name);
        Description = description;
        IsCustom = isCustom;
        DateCreated = DateTime.UtcNow;
        User = user;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Name of exercise cannot be null");
        Name = name;
    }
}