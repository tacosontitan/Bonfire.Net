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

using Bonfire.Hosting.ServiceProcess;

using Microsoft.Extensions.DependencyInjection;

namespace Bonfire.Hosting;

/// <summary>
/// Extension methods for running a <see cref="WindowsService"/> in a <see cref="IIgnitable"/> instance.
/// </summary>
public static class IgnitableExtensions
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
        instance.Configure(hostBuilder => hostBuilder.ConfigureServices((_, services) => services.AddHostedService<T>())).Run();
}
