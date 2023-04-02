namespace Microsoft.Extensions.Hosting;

/// <summary>
/// Extension methods for setting up Windows services in an <see cref="IHostBuilder" />.
/// </summary>
public static class HostingExtensions
{
    /// <summary>
    /// Specifies the startup type to be used by the host.
    /// </summary>
    /// <typeparam name="T">The type containing the startup methods for the application.</typeparam>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    public static IHostBuilder UseStartup<T>(this IHostBuilder hostBuilder)
        where T : class, new()
    {
        return hostBuilder.ConfigureServices((hostContext, services) =>
        {
            var startup = new T();
            typeof(T).InvokeMember(
                "ConfigureServices",
                System.Reflection.BindingFlags.InvokeMethod,
                null,
                startup,
                new object[] { services }
            );
        });
    }
}
