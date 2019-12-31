using DB.Api.Application.Commands;
using FluentValidation;

namespace DB.Api.Application.Validators.Commands
{
    public class DeleteRefreshTokenCommandValidator : AbstractValidator<DeleteRefreshTokenCommand>
    {
        public DeleteRefreshTokenCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Must be greater than or equal to 1");
        }
    }
}
