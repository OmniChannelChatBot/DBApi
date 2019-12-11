using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Commands
{
    public class CreateUserCommand: IRequest<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
