using GymWatch.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymWatch.Infrastructure.EF.Mappings;

public class TrainingInstanceMap : IEntityTypeConfiguration<TrainingInstance>
{
    public void Configure(EntityTypeBuilder<TrainingInstance> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.TrainingInstanceExercises)
            .WithOne(x => x.TrainingInstance)
            .HasForeignKey(x => x.TrainingInstanceId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.ToTable("TrainingInstances");
    }
}