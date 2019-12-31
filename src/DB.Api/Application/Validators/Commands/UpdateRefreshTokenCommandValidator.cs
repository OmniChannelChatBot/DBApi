using DB.Api.Application.Commands;
using FluentValidation;
using System.Net;

namespace DB.Api.Application.Validators.Commands
{
    public class UpdateRefreshTokenCommandValidator : AbstractValidator<UpdateRefreshTokenCommand>
    {
        public UpdateRefreshTokenCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Must be greater than or equal to 1");
            RuleFor(command => command.UserId)
                .GreaterThanOrEqualTo(1)
                .When(s => s.UserId.HasValue)
                .WithMessage("Must be greater than or equal to 1");
            RuleFor(command => command.RemoteIpAddress)
                .Must(s => IPAddress.TryParse(s, out var _))
                .When(s => !string.IsNullOrEmpty(s.RemoteIpAddress))
                .WithMessage("Must match IP Address");
        }
    }
}
