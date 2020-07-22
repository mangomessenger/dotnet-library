using AutoMapper;
using ServicesLibrary.DTO;

namespace ServicesLibrary.MapperProfiles
{
    public class AuthProfiles : Profile
    {
        public AuthProfiles()
        {
            CreateMap<SendCodeResult, SignUpPayload>();
        }
    }
}