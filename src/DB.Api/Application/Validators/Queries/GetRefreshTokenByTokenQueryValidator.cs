using DB.Api.Application.Queries;
using FluentValidation;

namespace DB.Api.Application.Validators.Queries
{
    public class GetRefreshTokenByTokenQueryValidator : AbstractValidator<GetRefreshTokenByTokenQuery>
    {
        public GetRefreshTokenByTokenQueryValidator()
        {
            RuleFor(query => query.Token)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
        }
    }
}
