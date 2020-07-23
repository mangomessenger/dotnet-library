using AutoMapper;
using ServicesLibrary.MapperFiles.Profiles;

namespace ServicesLibrary.MapperFiles
{
    public static class MapperFactory
    {
        public static Mapper GetMapperInstance()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AuthProfiles());
            });

            return new Mapper(configuration);
        }
    }
}