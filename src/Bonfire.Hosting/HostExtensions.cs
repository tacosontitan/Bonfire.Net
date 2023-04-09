/**************************************************************************
 * Copyright 2023 tacosontitan and contributors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 **************************************************************************/

using System;

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting;

/// <summary>
/// Extension methods for setting up Windows services in an <see cref="IHostBuilder" />.
/// </summary>
public static class HostExtensions
{
    /// <summary>
    /// Specifies the startup type to be used by the host.
    /// </summary>
    /// <typeparam name="T">The type containing the startup methods for the application.</typeparam>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    public static IHostBuilder UseStartup<T>(this IHostBuilder hostBuilder)
        where T : class, new()
    {
        return hostBuilder.ConfigureServices((_, services) =>
        {
            var startup = new T();
            Configure(startup, hostBuilder);
            ConfigureServices(startup, services);
        });
    }

    private static void Configure<T>(T startup, IHostBuilder builder)
    {
        try
        {
            // Invoke the Configure method on the startup instance.
            _ = typeof(T).InvokeMember(
                "Configure",
                System.Reflection.BindingFlags.InvokeMethod,
                null,
                startup,
                new object[] { builder }
            );
        }
        catch (MissingMethodException) { /* Gracefully ignore. */ }
    }

    private static void ConfigureServices<T>(T startup, IServiceCollection services)
    {
        try
        {
            // Invoke the ConfigureServices method on the startup instance.
            _ = typeof(T).InvokeMember(
                "ConfigureServices",
                System.Reflection.BindingFlags.InvokeMethod,
                null,
                startup,
                new object[] { services }
            );
        }
        catch (MissingMethodException) { /* Gracefully ignore. */ }
    }
}
