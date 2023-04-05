using Microsoft.Extensions.DependencyInjection;

namespace StandardizedStartup.Mocking;

internal class DefaultStartup
{
    public virtual void ConfigureServices(IServiceCollection services) =>
        services.AddHostedService<PrinterService>();
}