using Bonfire.Hosting.ServiceProcess;

using Microsoft.Extensions.DependencyInjection;

namespace Bonfire.Hosting;

/// <summary>
/// Extension methods for running a <see cref="WindowsService"/> in a <see cref="IIgnitable"/> instance.
/// </summary>
public static class IgnitableWindowsServiceExtensions
{
    /// <summary>
    /// Runs the specified <see cref="WindowsService"/> type.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="WindowsService"/> to run.</typeparam>
    /// <param name="instance">The <see cref="IIgnitable"/> instance.</param>
    /// <remarks>
    /// This method should be called from the main thread of your application.
    /// </remarks>
    public static void Run<T>(this IIgnitable instance)
        where T : WindowsService =>
        instance.Configure(hostBuilder => hostBuilder.ConfigureServices((_, services) => {
            services.AddHostedService<T>();
        })).Run();
}
