using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Commands
{
    public class DeleteUserCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
