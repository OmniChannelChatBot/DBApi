using AutoMapper;
using DB.Api.Application.Models;
using DB.Core.Entities.Identity;

namespace DB.Api.Application.Mappings
{
    public class UserEntity_GetUserByUsernameQueryResponse_Profile : Profile
    {
        public UserEntity_GetUserByUsernameQueryResponse_Profile() =>
            CreateMap<UserEntity, GetUserByUsernameQueryResponse>();
    }
}
