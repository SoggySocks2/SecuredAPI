using AutoMapper;
using SecuredAPI.ApiGateway.Api.Features.Identity.Models;
using SecuredAPI.Identity.Features.Roles;

namespace SecuredAPI.ApiGateway.Api.Features.Identity.Mapping
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<RoleModel, RoleDto>().ReverseMap();
            CreateMap<RoleInfoModel, RoleInfoDto>().ReverseMap();
            CreateMap<PermissionModel, PermissionDto>().ReverseMap();

            CreateMap<CreateRoleDto, CreateRoleModel>();
            CreateMap<CreateRoleModel, CreateRoleDto>()
                .ForMember(dest => dest.SelectedPermissionIds, opt => opt.Condition(src => src.SelectedPermissionIds is not null));

            CreateMap<UpdateRoleDto, UpdateRoleModel>();
            CreateMap<UpdateRoleModel, UpdateRoleDto>()
                .ForMember(dest => dest.SelectedPermissionIds, opt => opt.Condition(src => src.SelectedPermissionIds is not null));
        }
    }
}
