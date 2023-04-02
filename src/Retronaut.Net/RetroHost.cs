using Microsoft.Extensions.Hosting;

namespace Retronaut.Net;

/// <summary>
/// Represents a minimal host for running a <see cref="WindowsService"/>.
/// </summary>
public class RetroHost
{
    internal IHostBuilder HostBuilder { get; private set; }
    private RetroHost(IHostBuilder hostBuilder) =>
        HostBuilder = hostBuilder;
    /// <summary>
    /// Specifies the startup type to be used by the host.
    /// </summary>
    /// <typeparam name="T">The type containing the startup methods for the application.</typeparam>
    /// <param name="args">The command line args.</param>
    /// <returns>A <see cref="RetroHost"/> instance.</returns>
    public static RetroHost UseStartup<T>(string[] args)
        where T : class, new()
    {
        var hostBuilder = Host.CreateDefaultBuilder(args)
            .UseStartup<T>();

        return new RetroHost(hostBuilder);
    }
    /// <summary>
    /// Runs the the application with hosting and dependency injection support.
    /// </summary>
    /// <remarks>
    /// This method should be called from the main thread of your application.
    /// </remarks>
    public void Run()
    {
        IHost host = HostBuilder.Build();
        host.Run();
    }
}
