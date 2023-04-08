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
using Microsoft.Extensions.Hosting;

namespace Bonfire.Hosting;

/// <summary>
/// Defines a simplified extension methods for running applications using <see cref="IIgnitable"/>.
/// </summary>
public static class Ignite
{
    /// <summary>
    /// Creates a new <see cref="IIgnitable"/> instance using the specified startup type.
    /// </summary>
    /// <typeparam name="T">The type containing the startup methods for the application.</typeparam>
    /// <param name="args">The command line arguments to be passed to the application.</param>
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
    /// <param name="args"></param>
    /// <returns>The current <see cref="IIgnitable"/> instance.</returns>
    public static IIgnitable Configure(Action<IHostBuilder> configure, params string[] args) =>
        new IgnitableHost(args).Configure(configure);
}
