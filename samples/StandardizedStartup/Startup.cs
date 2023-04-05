using StandardizedStartup.Mocking;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleExample;

internal sealed class Startup : DefaultStartup
{
    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        _ = services.AddHostedService<FibonacciService>();
    }
}
