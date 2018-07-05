using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.App_Start
{
    public class MapperConfig
    {
        public static void Configure(ContainerBuilder builder)
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfiles(typeof(MapperConfigProfile).Assembly);
            });

            builder.RegisterInstance(config).As<MapperConfiguration>();
            builder.RegisterInstance(config.CreateMapper()).As<IMapper>();
        }
    }
}