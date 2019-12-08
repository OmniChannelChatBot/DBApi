using DB.Api.Application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Queries
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponse>
    {
        [Required]
        public int Id { get; set; }
    }
}
