using AutoMapper;
using DB.Api.Application.Models;
using DB.Core.Entities.Identity;

namespace DB.Api.Application.Mappings
{
    public class RefreshTokenEntity_GetRefreshTokenByTokenQueryResponse_Profile : Profile
    {
        public RefreshTokenEntity_GetRefreshTokenByTokenQueryResponse_Profile() =>
            CreateMap<RefreshTokenEntity, GetRefreshTokenByTokenQueryResponse>();
    }
}
