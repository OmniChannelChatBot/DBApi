using DB.Api.Application.Commands;
using FluentValidation;
using System;
using System.Net;

namespace DB.Api.Application.Validators.Commands
{
    public class AddRefreshTokenCommandValidator : AbstractValidator<AddRefreshTokenCommand>
    {
        public AddRefreshTokenCommandValidator()
        {
            RuleFor(command => command.UserId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Must be greater than or equal to 1");
            RuleFor(command => command.Token)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
            RuleFor(command => command.Expires)
                .GreaterThan(DateTimeOffset.UtcNow)
                .WithMessage("Must be greater than current date");
            RuleFor(command => command.RemoteIpAddress)
                .Must(s => IPAddress.TryParse(s, out var _))
                .When(s => !string.IsNullOrEmpty(s.RemoteIpAddress))
                .WithMessage("Must match IP Address");
        }
    }
}
