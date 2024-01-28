namespace GymWatch.Core.Domain.Abstraction;

public interface IModel<T>
{
    T Id { get; set; }
}