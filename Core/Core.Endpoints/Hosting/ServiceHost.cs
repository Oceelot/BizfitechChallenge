using System;
using ServiceStack;

namespace Core.Endpoints.Hosting
{
    public class ServiceHost : IDisposable
    {
        private readonly AppHostHttpListenerBase _appHost;
        private readonly ServiceConfiguration _serviceConfiguration;

        public ServiceHost(AppHostHttpListenerBase appHost, ServiceConfiguration serviceConfiguration)
        {
            _appHost = appHost;
            _serviceConfiguration = serviceConfiguration;
        }

        public void StartService()
        {
            _appHost.Init();
            var listeningAtUrlBase = _serviceConfiguration.Url();
            _appHost.Start(listeningAtUrlBase);
        }

        public void StopService()
        {
            if (_appHost.HasStarted)
                _appHost.Stop();

            _appHost.Dispose();
        }

        public void Dispose()
        {
            StopService();
        }
    }
}