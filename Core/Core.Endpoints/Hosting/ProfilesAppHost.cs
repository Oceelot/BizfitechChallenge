using System;
using System.Configuration;
using System.Reflection;
using ServiceStack;
using StructureMap;
using Container = Funq.Container;

namespace Core.Endpoints.Hosting
{
    public class ProfilesAppHost : AppHostHttpListenerPoolBase
    {
        private readonly Registry[] _structureMapRegistries;

        private static readonly int ServiceStackThreadPoolSize =
           Convert.ToInt32(ConfigurationManager.AppSettings["ServiceStackThreadPoolSize"]);

        public ProfilesAppHost(string serviceName, Assembly[] endpointAssemblies, Registry[] structureMapRegistries)
            : base(serviceName, ServiceStackThreadPoolSize, endpointAssemblies)
        {
            _structureMapRegistries = structureMapRegistries;
        }

        public override void Configure(Container container)
        {
            
        }
    }
}