using System.Data;
using GymWatch.Core.Domain.Abstraction;
using GymWatch.Core.Domain.Enums;

namespace GymWatch.Core.Domain.Models;

public class Exercise : IModel, ISoftDeletable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public BodyPart BodyPart { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsCustom { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
    public bool IsDeleted { get; set; }

    protected Exercise() { }

    public Exercise(string name, string? description, BodyPart bodyPart, bool isCustom)
    {
        SetName(name);
        Description = description;
        BodyPart = bodyPart;
        IsCustom = isCustom;
        DateCreated = DateTime.UtcNow;
    }
    
    public Exercise(string name, string? description, BodyPart bodyPart, bool isCustom, User? user)
    {
        SetName(name);
        Description = description;
        BodyPart = bodyPart;
        IsCustom = isCustom;
        DateCreated = DateTime.UtcNow;
        User = user;
    }

    public void Update(string name, string? description, BodyPart bodyPart)
    {
        SetName(name);
        Description = description;
        BodyPart = bodyPart;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Name of exercise cannot be null");
        Name = name;
    }
    public void Delete()
    {
        IsDeleted = true;
    }
}