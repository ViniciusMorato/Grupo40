using Adapter.Api.DTO;
using AutoMapper;
using Core.Entities;

namespace Adapter.Api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<AddUserDto, Usuario>();
        CreateMap<Usuario, UserDto>();
    }
}