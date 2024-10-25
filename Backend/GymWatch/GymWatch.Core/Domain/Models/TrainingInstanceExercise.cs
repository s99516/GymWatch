using GymWatch.Core.Domain.Abstraction;

namespace GymWatch.Core.Domain.Models;

public class TrainingInstanceExercise : IModel
{
    public int Id { get; set; }
    public int Sequence { get; set; }
    public int NumberOfSeries { get; set; }
    public double Weight { get; set; }

    public int TrainingInstanceId { get; set; }
    public TrainingInstance TrainingInstance { get; set; }
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    
    public TrainingInstanceExercise() { }

    public TrainingInstanceExercise(int sequence, int numberOfSeries, double weight, TrainingInstance trainingInstance, Exercise exercise)
    {
        SetSequence(sequence);
        SetNumberOfSeries(numberOfSeries);
        SetWeight(weight);
        TrainingInstance = trainingInstance;
        Exercise = exercise;
    }
    
    private void SetSequence(int sequence)
    {
        if (sequence <= 0) throw new ArgumentException("Wrong sequence provided");
        Sequence = sequence;
    }
    
    private void SetNumberOfSeries(int numberOfSeries)
    {
        if (numberOfSeries <= 0) throw new ArgumentException("Wrong number of series provided");
        NumberOfSeries = numberOfSeries;
    }
    
    private void SetWeight(double weight)
    {
        if (weight <= 0) throw new ArgumentException("Wrong weight provided");
        Weight = weight;
    }
}