using AutoMapper;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;

namespace MusicStore.Services.Profiles
{
    public class GenderProfile: Profile
    {
        public GenderProfile() { 
            CreateMap<Gender, GenderDtoResponse>();
            CreateMap<GenderDtoRequest, Gender>();
        }
    }
}
