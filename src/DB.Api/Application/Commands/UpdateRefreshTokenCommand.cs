using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Commands
{
    public class UpdateRefreshTokenCommand : IRequest
    {
        [Required]
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string Token { get; set; }

        public DateTimeOffset? Expires { get; set; }

        public string RemoteIpAddress { get; set; }
    }
}
