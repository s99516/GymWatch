using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.EF.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GymWatch.Infrastructure.EF;

public class GymWatchDbContext : DbContext
{
    public GymWatchDbContext(DbContextOptions<GymWatchDbContext> options) : base(options)
    {
        
    }
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<TrainingInstance> TrainingInstances { get; set; }
    public virtual DbSet<TrainingInstanceExercise> TrainingInstanceExercises { get; set; }
    public virtual DbSet<Exercise> Exercises { get; set; }
    public virtual DbSet<Log> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TrainingInstanceMap());
        modelBuilder.ApplyConfiguration(new TrainingInstanceExerciseMap());
        modelBuilder.ApplyConfiguration(new ExerciseMap());
        modelBuilder.ApplyConfiguration(new LogMap());
    }
}