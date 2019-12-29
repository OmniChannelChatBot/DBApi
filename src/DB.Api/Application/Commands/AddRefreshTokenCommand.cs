using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Commands
{
    public class AddRefreshTokenCommand : IRequest<int>
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTimeOffset Expires { get; set; }

        public string RemoteIpAddress { get; set; }
    }
}
