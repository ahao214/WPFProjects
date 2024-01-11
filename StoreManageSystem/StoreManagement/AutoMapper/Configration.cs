using AutoMapper;
using StoreManagement.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.AutoMapper
{
    public class Configration
    {
        public static IMapper Mapper;

        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InStoreExProfile>();
            });

            Mapper = config.CreateMapper();

        }

    }
}
