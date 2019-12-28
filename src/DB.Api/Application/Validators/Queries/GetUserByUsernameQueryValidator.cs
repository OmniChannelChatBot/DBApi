using DB.Api.Application.Queries;
using FluentValidation;

namespace DB.Api.Application.Validators.Queries
{
    public class GetUserByUsernameQueryValidator : AbstractValidator<GetUserByUsernameQuery>
    {
        public GetUserByUsernameQueryValidator()
        {
            RuleFor(query => query.Username)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
        }
    }
}
