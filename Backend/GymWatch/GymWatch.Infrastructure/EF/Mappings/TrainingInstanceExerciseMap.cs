using GymWatch.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymWatch.Infrastructure.EF.Mappings;

public class TrainingInstanceExerciseMap : IEntityTypeConfiguration<TrainingInstanceExercise>
{
    public void Configure(EntityTypeBuilder<TrainingInstanceExercise> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Exercise)
            .WithMany()
            .HasForeignKey(x => x.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("TrainingInstanceExercises");
    }
}