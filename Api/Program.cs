using Api;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(workerApplication =>
    {
        workerApplication.UseAspNetCoreIntegration();
    })
    .ConfigureAspNetCoreIntegration()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IProductData, ProductData>();
    })
    .Build();

host.Run();
