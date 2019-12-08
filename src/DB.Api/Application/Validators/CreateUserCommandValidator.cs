using DB.Api.Application.Commands;
using FluentValidation;

namespace DB.Api.Application.Validators
{
    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command => command.Email)
                .NotNull()
                .WithMessage("Не заполнено");
        }
    }
}
