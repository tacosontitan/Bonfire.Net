/*
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
 */

using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

namespace Bonfire.Hosting;

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
    /// <summary>
    /// Runs the the application with hosting and dependency injection support.
    /// </summary>
    /// <remarks>
    /// This method should be called from the main thread of your application.
    /// </remarks>
    Task RunAsync();
}
