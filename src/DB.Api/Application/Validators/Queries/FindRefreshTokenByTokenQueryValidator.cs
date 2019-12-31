using DB.Api.Application.Queries;
using FluentValidation;

namespace DB.Api.Application.Validators.Queries
{
    public class FindRefreshTokenByTokenQueryValidator : AbstractValidator<FindRefreshTokenByTokenQuery>
    {
        public FindRefreshTokenByTokenQueryValidator()
        {
            RuleFor(query => query.Token)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
        }
    }
}
