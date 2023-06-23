using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api;

public class Program
{
    public static void Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults(workerApplication =>
            {
                workerApplication.UseAspNetCoreIntegration();
            })
            .ConfigureServices(services =>
            {
                services.AddSingleton<IProductData, ProductData>();
            })
            .Build();

        host.Run();
    }
}
