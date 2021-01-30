using AutoMapper;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.Mappers;

namespace YAHRA.App_Start
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddProfile<EmployeeMapperProfile>();
                cfg.AddMaps(GetType().Assembly);
            });

            return config;
        }
    }
}