using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Retronaut.Net.Windows;

/// <summary>
/// Represents a modern-ish Windows service.
/// </summary>
public abstract class WindowsService : ServiceBase, IHostedService
{
    public virtual void Configure(IServiceCollection services) { }
    public Task StartAsync(CancellationToken cancellationToken) {
        ServiceBase.Run(this);
        return Task.CompletedTask;
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        Stop();
        return Task.CompletedTask;
    }
}
