using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Commands
{
    public class AddUserCommand : IRequest<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public string Email { get; set; }

        public short? Type { get; set; }
    }
}
