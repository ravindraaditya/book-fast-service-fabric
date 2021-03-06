using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using System;
using System.Fabric;
using System.IO;

namespace BookFast.ServiceFabric
{
    public static class ServiceReplicaListenerFactory
    {
        public static ServiceReplicaListener CreateListener(Type startupType, IReliableStateManager stateManager, Action<StatefulServiceContext, string> loggingCallback)
        {
            return new ServiceReplicaListener(serviceContext =>
            {
                return new KestrelCommunicationListener(serviceContext, (url, listener) =>
                {
                    loggingCallback(serviceContext, $"Starting Kestrel on {url}");

                    return new WebHostBuilder().UseKestrel()
                                .ConfigureServices(services =>
                                {
                                    services.AddSingleton(serviceContext);
                                    services.AddSingleton(stateManager);
                                })
                                .UseContentRoot(Directory.GetCurrentDirectory())
                                .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.UseUniqueServiceUrl)
                                .UseStartup(startupType)
                                .UseUrls(url)
                                .Build();
                });
            });
        }
    }
}
