using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Models
{
    public class FindRefreshTokenByTokenQueryResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTimeOffset Expires { get; set; }
    }
}
