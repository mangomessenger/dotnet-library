using AutoMapper;
using ServicesLibrary.Models;

namespace ServicesLibrary.MapperFiles.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            // source -> target
            CreateMap<AuthRequest, RegisterPayload>();
            CreateMap<RegisterPayload, LoginPayload>();
            CreateMap<AuthRequest, LoginPayload>();
        }
    }
}