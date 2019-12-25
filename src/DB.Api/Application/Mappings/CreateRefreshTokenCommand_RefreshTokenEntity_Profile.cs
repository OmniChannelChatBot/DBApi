using AutoMapper;
using DB.Api.Application.Commands;
using DB.Core.Entities.Identity;
using System;

namespace DB.Api.Application.Mappings
{
    public class CreateRefreshTokenCommand_RefreshTokenEntity_Profile : Profile
    {
        public CreateRefreshTokenCommand_RefreshTokenEntity_Profile()
        {
            CreateMap<CreateRefreshTokenCommand, RefreshTokenEntity>()
                .ForMember(d => d.Guid, mo => mo.MapFrom(m => Guid.NewGuid()))
                .ForMember(d => d.CreateDate, mo => mo.MapFrom(m => DateTimeOffset.UtcNow))
                .ForMember(d => d.UpdateDate, mo => mo.MapFrom(m => DateTimeOffset.UtcNow));
        }
    }
}
