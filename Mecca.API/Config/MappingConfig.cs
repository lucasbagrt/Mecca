using AutoMapper;
using Mecca.API.Data.ValueObjects;
using Mecca.API.Model;

namespace Mecca.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<UserVO, User>().ReverseMap();                
            });
            return mappingConfig;
        }
    }
}
