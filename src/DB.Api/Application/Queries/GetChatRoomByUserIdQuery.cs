using DB.Api.Application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Queries
{
    public class GetChatRoomByUserIdQuery: IRequest<GetChatRoomByUserIdQueryResponse>
    {
        [Required]
        public int Id { get; set; }
    }
}
