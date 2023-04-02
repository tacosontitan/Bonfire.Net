using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Retronaut.Net.Windows;

namespace Retronaut.Net;

/// <summary>
/// Extension methods for running a <see cref="WindowsService"/> in a <see cref="RetroHost"/> instance.
/// </summary>
public static class RetroHostWindowsServiceExtensions
{
    /// <summary>
    /// Runs the specified <see cref="WindowsService"/> type.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="WindowsService"/> to run.</typeparam>
    /// <param name="instance">The <see cref="RetroHost"/> instance.</param>
    /// <remarks>
    /// This method should be called from the main thread of your application.
    /// </remarks>
    public static void Run<T>(this IRetroHost instance)
        where T : WindowsService =>
        instance.Configure(hostBuilder => hostBuilder.ConfigureServices((_, services) => {
            services.AddHostedService<T>();
        })).Run();
}
