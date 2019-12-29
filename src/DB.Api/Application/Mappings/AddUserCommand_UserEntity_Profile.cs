using AutoMapper;
using DB.Api.Application.Commands;
using DB.Core.Entities.Identity;
using System;

namespace DB.Api.Application.Mappings
{
    public class AddUserCommand_UserEntity_Profile : Profile
    {
        public AddUserCommand_UserEntity_Profile()
        {
            CreateMap<AddUserCommand, UserEntity>()
                .ForMember(d => d.Guid, mo => mo.MapFrom(m => Guid.NewGuid()))
                .ForMember(d => d.CreateDate, mo => mo.MapFrom(m => DateTimeOffset.UtcNow))
                .ForMember(d => d.UpdateDate, mo => mo.MapFrom(m => DateTimeOffset.UtcNow))
                .ForMember(d => d.Type, mo => mo.MapFrom(m => m.Type ?? 1));
        }
    }
}
