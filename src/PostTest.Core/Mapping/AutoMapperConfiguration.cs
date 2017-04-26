using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PostTest.Core.Mapping.Profiles;

namespace PostTest.Core.Mapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper CreateMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntityToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToEntitylMappingProfile>();
            }).CreateMapper();
        }
    }
}
