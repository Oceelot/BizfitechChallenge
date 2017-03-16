using Core.Endpoints.Hosting;
using StructureMap;
using Topshelf;

namespace Query
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryWebServiceHost = new ProfilesAppHostBuilder()
                .AsServiceName("Query")
                .WithEndpointAssemblies(new[] { typeof(Program).Assembly })
                .WithRegistries(new Registry[] { new WebQueryRegistry() })
                .CreateServiceHost();

            HostFactory.Run(ts =>
            {
                ts.Service<ServiceHost>(service =>
                {
                    service.ConstructUsing(s => queryWebServiceHost);
                    service.WhenStarted(s => s.StartService());
                    service.WhenStopped(s => s.StopService());
                });
                ts.RunAsLocalSystem();
                ts.SetDisplayName("Programmers Profiles Queries");
                ts.SetServiceName("programmers-profiles-web-query");
            });
        }
    }
}
