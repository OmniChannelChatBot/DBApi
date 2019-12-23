using DB.Api.Application.Commands;
using FluentValidation;

namespace DB.Api.Application.Validators.Commands
{
    public class CreateRefreshTokenCommandValidator : AbstractValidator<CreateRefreshTokenCommand>
    {
        public CreateRefreshTokenCommandValidator()
        {
            RuleFor(command => command.UserId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Must be greater than or equal to 1");
            RuleFor(command => command.Token)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
            RuleFor(command => command.Expires);
            RuleFor(command => command.RemoteIpAddress);
        }
    }
}
