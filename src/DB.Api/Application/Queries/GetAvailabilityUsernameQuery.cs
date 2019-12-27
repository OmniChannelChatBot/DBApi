using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Queries
{
    public class GetAvailabilityUsernameQuery : IRequest<bool>
    {
        [Required]
        public string Username { get; set; }
    }
}
