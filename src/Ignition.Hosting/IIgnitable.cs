using System;
using Microsoft.Extensions.Hosting;

namespace Ignition.Net;

/// <summary>
/// Defines a common interface for building an <see cref="IHost"/> instance using Retronaut.Net.
/// </summary>
public interface IIgnitable
{
    /// <summary>
    /// Specifies the startup type to be used by the host.
    /// </summary>
    /// <typeparam name="T">The type containing the startup methods for the application.</typeparam>
    /// <param name="args">The command line args.</param>
    /// <returns>A <see cref="IIgnitable"/> instance.</returns>
    IIgnitable UseStartup<T>(params string[] args) where T : class, new();
    /// <summary>
    /// Configures the host using the specified <see cref="Action{T}"/>.
    /// </summary>
    /// <param name="configure">The <see cref="Action{T}"/> to configure the host.</param>
    /// <returns>The current <see cref="IIgnitable"/> instance.</returns>
    IIgnitable Configure(Action<IHostBuilder> configure);
    /// <summary>
    /// Runs the the application with hosting and dependency injection support.
    /// </summary>
    /// <remarks>
    /// This method should be called from the main thread of your application.
    /// </remarks>
    void Run();
}
