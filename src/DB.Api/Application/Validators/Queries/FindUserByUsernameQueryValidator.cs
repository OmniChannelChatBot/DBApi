using DB.Api.Application.Queries;
using FluentValidation;

namespace DB.Api.Application.Validators.Queries
{
    public class FindUserByUsernameQueryValidator : AbstractValidator<FindUserByUsernameQuery>
    {
        public FindUserByUsernameQueryValidator()
        {
            RuleFor(query => query.Username)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
        }
    }
}
