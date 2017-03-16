using System;
using System.Configuration;
using System.Reflection;
using ServiceStack;
using ServiceStack.Text;
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
            JsConfig.AlwaysUseUtc = true;
            JsConfig.EmitCamelCaseNames = true;
            JsConfig.ExcludeTypeInfo = true;
            JsConfig.IncludeNullValues = true;
        }
    }
}