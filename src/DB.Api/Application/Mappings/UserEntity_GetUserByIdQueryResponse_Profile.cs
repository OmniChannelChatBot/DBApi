using AutoMapper;
using DB.Api.Application.Models;
using DB.Core.Entities.Identity;

namespace DB.Api.Application.Mappings
{
    public class UserEntity_GetUserByIdQueryResponse_Profile : Profile
    {
        public UserEntity_GetUserByIdQueryResponse_Profile() =>
            CreateMap<UserEntity, GetUserByIdQueryResponse>();
    }
}
