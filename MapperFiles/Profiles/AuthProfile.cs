using AutoMapper;
using ServicesLibrary.DTO;
using ServicesLibrary.Models;

namespace ServicesLibrary.MapperFiles.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            // source -> target
            CreateMap<AuthRequest, SignUpPayload>();
            CreateMap<SignUpPayload, SignInPayload>();
            CreateMap<AuthRequest, SignInPayload>();
        }
    }
}