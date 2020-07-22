using AutoMapper;
using ServicesLibrary.DTO;

namespace ServicesLibrary.MapperProfiles
{
    public class AuthProfiles : Profile
    {
        public AuthProfiles()
        {
            // source -> target
            CreateMap<SendCodeResult, SignUpPayload>();
            CreateMap<SignUpPayload, SignInPayload>();
            CreateMap<SendCodeResult, SignInPayload>();
        }
    }
}