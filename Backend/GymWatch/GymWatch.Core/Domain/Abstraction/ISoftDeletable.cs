namespace GymWatch.Core.Domain.Abstraction;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    void Delete();
}