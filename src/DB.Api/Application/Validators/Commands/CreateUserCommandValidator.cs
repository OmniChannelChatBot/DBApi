using DB.Api.Application.Commands;
using FluentValidation;
using FluentValidation.Validators;

namespace DB.Api.Application.Validators.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command => command.FirstName)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
            RuleFor(command => command.LastName)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
            RuleFor(command => command.Username)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
            RuleFor(command => command.Password)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
            RuleFor(command => command.Email)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Do not match format");
            RuleFor(command => command.Type)
                .GreaterThanOrEqualTo(1)
                .When(w => w.Type.HasValue)
                .WithMessage("Must be greater than or equal to 1");
        }
    }
}
