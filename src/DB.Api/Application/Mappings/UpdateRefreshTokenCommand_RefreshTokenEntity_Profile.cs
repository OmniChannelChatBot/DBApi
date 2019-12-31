using AutoMapper;
using DB.Api.Application.Commands;
using DB.Core.Entities.Identity;
using System;

namespace DB.Api.Application.Mappings
{
    public class UpdateRefreshTokenCommand_RefreshTokenEntity_Profile : Profile
    {
        public UpdateRefreshTokenCommand_RefreshTokenEntity_Profile()
        {
            CreateMap<UpdateRefreshTokenCommand, RefreshTokenEntity>()
                .ForMember(d => d.UpdateDate, o => o.MapFrom(m => DateTimeOffset.UtcNow));
        }
    }
}
