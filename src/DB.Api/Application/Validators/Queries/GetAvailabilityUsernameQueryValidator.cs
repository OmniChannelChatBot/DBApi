using DB.Api.Application.Queries;
using FluentValidation;

namespace DB.Api.Application.Validators.Queries
{
    public class GetAvailabilityUsernameQueryValidator : AbstractValidator<GetAvailabilityUsernameQuery>
    {
        public GetAvailabilityUsernameQueryValidator()
        {
            RuleFor(query => query.Username)
                .NotNull()
                .WithMessage("Must not be null")
                .NotEmpty()
                .WithMessage("Should not be empty");
        }
    }
}
