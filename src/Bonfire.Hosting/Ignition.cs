using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bonfire.Hosting;

/// <summary>
/// Represents a basic startup class for a Bonfire application.
/// </summary>
public abstract class Ignition
{
    /// <summary>
    /// Configures the specified <see cref="IHostBuilder"/> instance.
    /// </summary>
    /// <param name="builder">The <see cref="IHostBuilder"/> instance to configure.</param>
    protected virtual void Configure(IHostBuilder builder) { }
    /// <summary>
    /// Configures the specified <see cref="IServiceCollection"/> instance.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure.</param>
    protected virtual void ConfigureServices(IServiceCollection services) { }
}
