using AutoMapper;
using DB.Api.Application.Commands;
using DB.Core.Entities.Identity;

namespace DB.Api.Application.Mappings
{
    public class DeleteRefreshTokenCommand_RefreshTokenEntity_Profile : Profile
    {
        public DeleteRefreshTokenCommand_RefreshTokenEntity_Profile()
        {
            CreateMap<DeleteRefreshTokenCommand, RefreshTokenEntity>()
                .ForMember(d => d.Id, mo => mo.MapFrom(m => m.Id))
                .ForAllOtherMembers(m => m.Ignore());
        }
    }
}
