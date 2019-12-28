using DB.Api.Application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Queries
{
    public class GetUserByUsernameQuery : IRequest<GetUserByUsernameQueryResponse>
    {
        [Required]
        public string Username { get; set; }
    }
}
