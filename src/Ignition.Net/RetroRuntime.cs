using System;
using Microsoft.Extensions.Hosting;

namespace Retronaut.Net;

/// <summary>
/// Defines a simplified extension methods for running applications using <see cref="IRetroHost"/>.
/// </summary>
public static class RetroRuntime
{
    /// <summary>
    /// Creates a new <see cref="IRetroHost"/> instance using the specified startup type.
    /// </summary>
    /// <param name="instance">The <see cref="IRetroHost"/> instance.</param>
    /// <remarks>
    /// This method should be called from the main thread of your application.
    /// </remarks>
    public static IRetroHost UseStartup<T>(params string[] args)
        where T : class, new() =>
        new RetroHost(args).UseStartup<T>(args);
    /// <summary>
    /// Configures a new host using the specified <see cref="Action{T}"/>.
    /// </summary>
    /// <param name="configure">The <see cref="Action{T}"/> to configure the host.</param>
    /// <returns>The current <see cref="IRetroHost"/> instance.</returns>
    public static IRetroHost Configure(Action<IHostBuilder> configure) =>
        new RetroHost().Configure(configure);
    /// <summary>
    /// Runs the the application with hosting support.
    /// </summary>
    public static void Run() =>
        new RetroHost().Run();
}
