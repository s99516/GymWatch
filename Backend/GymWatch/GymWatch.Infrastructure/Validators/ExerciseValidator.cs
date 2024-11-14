using FluentValidation;
using GymWatch.Core.Domain.Models;

namespace GymWatch.Infrastructure.Validators;

public class ExerciseValidator : AbstractValidator<Exercise>
{
    public ExerciseValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage($"Property {nameof(Exercise.Name)} cannot be empty")
            .MinimumLength(2)
            .WithMessage("Name must be at least 2 characters long");
    }
}