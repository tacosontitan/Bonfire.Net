using Microsoft.Extensions.DependencyInjection;

namespace ConsoleExample;

internal sealed class Startup
{
    public void ConfigureServices(IServiceCollection services) =>
        services.AddHostedService<FibonacciService>();
}
