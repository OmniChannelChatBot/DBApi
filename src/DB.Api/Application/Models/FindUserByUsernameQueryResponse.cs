using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Models
{
    public class FindUserByUsernameQueryResponse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public short Type { get; set; }
    }
}
