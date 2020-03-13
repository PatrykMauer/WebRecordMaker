using AutoMapper;
using RecordMaker.Core.Domain;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDto>();
                    cfg.CreateMap<Table, TableDto>();
                })
                .CreateMapper();
    }
}