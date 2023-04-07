using System;
using Microsoft.Extensions.Hosting;

namespace Ignition.Net;

/// <summary>
/// Defines a simplified extension methods for running applications using <see cref="IIgnitable"/>.
/// </summary>
public static class Ignite
{
    /// <summary>
    /// Creates a new <see cref="IIgnitable"/> instance using the specified startup type.
    /// </summary>
    /// <param name="instance">The <see cref="IIgnitable"/> instance.</param>
    /// <remarks>
    /// This method should be called from the main thread of your application.
    /// </remarks>
    public static IIgnitable UseStartup<T>(params string[] args)
        where T : class, new() =>
        new IgnitableHost(args).UseStartup<T>(args);
    /// <summary>
    /// Configures a new host using the specified <see cref="Action{T}"/>.
    /// </summary>
    /// <param name="configure">The <see cref="Action{T}"/> to configure the host.</param>
    /// <returns>The current <see cref="IIgnitable"/> instance.</returns>
    public static IIgnitable Configure(Action<IHostBuilder> configure) =>
        new IgnitableHost().Configure(configure);
    /// <summary>
    /// Runs the the application with hosting support.
    /// </summary>
    public static void Run() =>
        new IgnitableHost().Run();
}
