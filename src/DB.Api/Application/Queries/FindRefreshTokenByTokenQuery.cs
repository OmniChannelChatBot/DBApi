using DB.Api.Application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Queries
{
    public class FindRefreshTokenByTokenQuery : IRequest<FindRefreshTokenByTokenQueryResponse>
    {
        [Required]
        public string Token { get; set; }
    }
}
