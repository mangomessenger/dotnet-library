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
                cfg.AddProfile(new AuthProfile());
            });

            return new Mapper(configuration);
        }
    }
}