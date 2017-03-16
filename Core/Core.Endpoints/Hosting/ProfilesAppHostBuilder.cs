using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using StructureMap;

namespace Core.Endpoints.Hosting
{
    public interface IProfilesAppHostBuilder
    {
        IProfilesAppHostBuilder AsServiceName(string serviceName);
        IProfilesAppHostBuilder WithEndpointAssemblies(Assembly[] assemblies);
        IProfilesAppHostBuilder WithRegistries(Registry[] registries);

        AppHostHttpListenerBase CreateAppHost();
        ServiceHost CreateServiceHost();
    }

    public class ProfilesAppHostBuilder : IProfilesAppHostBuilder
    {
        private string _serviceName;
        private Assembly[] _assemblies;
        private Registry[] _registries;

        public IProfilesAppHostBuilder AsServiceName(string serviceName)
        {
            _serviceName = serviceName;
            return this;
        }

        public IProfilesAppHostBuilder WithEndpointAssemblies(Assembly[] assemblies)
        {
            _assemblies = assemblies;
            return this;
        }

        public IProfilesAppHostBuilder WithRegistries(Registry[] registries)
        {
            _registries = registries;
            return this;
        }

        public AppHostHttpListenerBase CreateAppHost()
        {
            return new ProfilesAppHost(_serviceName, _assemblies.ToArray(), _registries);
        }

        public ServiceHost CreateServiceHost()
        {
            return new ServiceHost(CreateAppHost(), new ServiceConfiguration());
        }
    }
}
