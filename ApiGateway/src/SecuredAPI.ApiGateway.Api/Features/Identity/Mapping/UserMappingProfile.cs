using AutoMapper;
using SecuredAPI.ApiGateway.Api.Features.Identity.Models;
using SecuredAPI.Identity.Features.Users;

namespace SecuredAPI.ApiGateway.Api.Features.Identity.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<RoleNameModel, RoleNameDto>().ReverseMap();


            CreateMap<CreateUserDto, CreateUserModel>();
            CreateMap<CreateUserModel, CreateUserDto>()
                .ForMember(dest => dest.RoleIds, opt => opt.Condition(src => src.RoleIds is not null));

            CreateMap<UpdateUserDto, UpdateUserModel>();
            CreateMap<UpdateUserModel, UpdateUserDto>()
                .ForMember(dest => dest.RoleIds, opt => opt.Condition(src => src.RoleIds is not null));
        }
    }
}
