using System;
using Microsoft.Extensions.Hosting;

namespace Retronaut.Net;

/// <summary>
/// Represents a minimal host running applications.
/// </summary>
public class RetroHost : IRetroHost
{
    private IHostBuilder _hostBuilder;
    /// <summary>
    /// Creates a new <see cref="RetroHost"/> instance.
    /// </summary>
    /// <param name="args">The command line args.</param>
    public RetroHost(params string[] args) =>
        _hostBuilder = Host.CreateDefaultBuilder(args);
    /// <summary>
    /// Configures the host using the specified <see cref="Action{T}"/>.
    /// </summary>
    /// <param name="configure">The <see cref="Action{T}"/> to configure the host.</param>
    /// <returns>The current <see cref="IRetroHost"/> instance.</returns>
    public IRetroHost Configure(Action<IHostBuilder> configure) {
        if (configure is null)
            throw new ArgumentNullException(nameof(configure));

        configure(_hostBuilder);
        return this;
    }
    /// <summary>
    /// Specifies the startup type to be used by the host.
    /// </summary>
    /// <typeparam name="T">The type containing the startup methods for the application.</typeparam>
    /// <param name="args">The command line args.</param>
    /// <returns>A <see cref="IRetroHost"/> instance.</returns>
    public IRetroHost UseStartup<T>(params string[] args)
        where T : class, new()
    {
        _hostBuilder = _hostBuilder.UseStartup<T>();
        return this;
    }
    /// <summary>
    /// Runs the the application with hosting and dependency injection support.
    /// </summary>
    /// <remarks>
    /// This method should be called from the main thread of your application.
    /// </remarks>
    public void Run()
    {
        IHost host = _hostBuilder.Build();
        host.Run();
    }
}
