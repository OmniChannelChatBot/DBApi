using MediatR;

namespace DB.Api.Application.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
