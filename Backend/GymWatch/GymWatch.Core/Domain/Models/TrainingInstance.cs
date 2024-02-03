using GymWatch.Core.Domain.Abstraction;
using GymWatch.Core.Domain.Enums;

namespace GymWatch.Core.Domain.Models;

public class TrainingInstance : IModel<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public double? BodyWeight { get; set; }
    public TrainingState State { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<TrainingInstanceExercise> TrainingInstanceExercises { get; set; }

    public TrainingInstance() { }

    public TrainingInstance(string name, double? bodyWeight, TrainingState state, User user)
    {
        SetName(name);
        SetBodyWeight(bodyWeight);
        State = state;
        User = user;
        Date = DateTime.UtcNow;
    }

    public void StartTrainingInstance()
    {
        State = TrainingState.Active;
    }
    
    public void EndTrainingInstance()
    {
        State = TrainingState.Ended;
    }
    
    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Name of training instance cannot be null");
        Name = name;
    }
    
    private void SetBodyWeight(double? bodyWeight)
    {
        if (bodyWeight <= 0) throw new ArgumentException("Wrong body weight provided");
        BodyWeight = bodyWeight;
    }
}