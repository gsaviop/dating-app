using api.DTOs;
using api.Entities;
using api.Extensions;
using AutoMapper;

namespace api.Helpers;

public class AutoMapperProfiles : Profile
{

    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.isMain).Url))
            .ForMember(dest => dest.Age, 
                opt => opt.MapFrom(src => src.DateOfBirth.calculateAge()));
        
        CreateMap<Photo, PhotoDto>();
    }
}
