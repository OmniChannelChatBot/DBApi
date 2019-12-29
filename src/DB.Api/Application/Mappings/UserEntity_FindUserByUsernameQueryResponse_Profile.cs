using AutoMapper;
using DB.Api.Application.Models;
using DB.Core.Entities.Identity;

namespace DB.Api.Application.Mappings
{
    public class UserEntity_FindUserByUsernameQueryResponse_Profile : Profile
    {
        public UserEntity_FindUserByUsernameQueryResponse_Profile() =>
            CreateMap<UserEntity, FindUserByUsernameQueryResponse>();
    }
}
