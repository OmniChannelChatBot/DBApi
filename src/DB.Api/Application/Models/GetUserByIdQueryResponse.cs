using System;

namespace DB.Api.Application.Models
{
    public class GetUserByIdQueryResponse
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
