using AutoMapper;
using PocApi.DTOs;
using PocApi.Entities;

namespace PocApi.Shared.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserToInsertDTO, User>().ReverseMap();
            CreateMap<UserToInsertDTO, UserDTO>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
