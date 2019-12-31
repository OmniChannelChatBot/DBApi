using AutoMapper;
using DB.Api.Application.Models;
using DB.Core.Entities.Identity;

namespace DB.Api.Application.Mappings
{
    public class RefreshTokenEntity_FindRefreshTokenByTokenQueryResponse_Profile : Profile
    {
        public RefreshTokenEntity_FindRefreshTokenByTokenQueryResponse_Profile() =>
            CreateMap<RefreshTokenEntity, FindRefreshTokenByTokenQueryResponse>();
    }
}
