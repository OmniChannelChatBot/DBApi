using DB.Api.Application.Commands;
using FluentValidation;

namespace DB.Api.Application.Validators.Commands
{
    public class AddMessangerCommandValidator : AbstractValidator<AddMessangerCommand>
    {
        public AddMessangerCommandValidator()
        {
            RuleFor(command => command.Token)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
            RuleFor(command => command.Type)
                .GreaterThanOrEqualTo((short)1)
                .WithMessage("Must be greater than or equal to 1");
        }
    }
}
