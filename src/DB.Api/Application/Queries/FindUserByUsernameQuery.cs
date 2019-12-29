using DB.Api.Application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Queries
{
    public class FindUserByUsernameQuery : IRequest<FindUserByUsernameQueryResponse>
    {
        [Required]
        public string Username { get; set; }
    }
}
