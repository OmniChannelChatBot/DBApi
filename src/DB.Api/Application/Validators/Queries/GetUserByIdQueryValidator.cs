using DB.Api.Application.Queries;
using FluentValidation;

namespace DB.Api.Application.Validators.Queries
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(query => query.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Must be greater than zero");
        }
    }
}
