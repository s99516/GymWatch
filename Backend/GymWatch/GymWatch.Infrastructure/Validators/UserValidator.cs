using FluentValidation;
using GymWatch.Core.Domain.Models;

namespace GymWatch.Infrastructure.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Email).NotEmpty()
            .WithMessage($"Property {nameof(User.Email)} cannot be empty")
            .Matches("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$");
        
        RuleFor(x => x.Password).NotEmpty()
            .WithMessage($"Property {nameof(User.Password)} cannot be empty")
            .MinimumLength(8).WithMessage($"Property {nameof(User.Password)} must be at least 8 characters");
    }
}