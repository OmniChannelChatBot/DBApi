using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Commands
{
    public class DeleteRefreshTokenCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
