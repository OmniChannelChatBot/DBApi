using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Commands
{
    public class AddMessangerCommand : IRequest<int>
    {
        [Required]
        public short Type { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
