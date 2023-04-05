using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StandardizedStartup.Mocking;

internal sealed class PrinterService : IHostedService
{
    private ILogger _logger;
    public PrinterService(ILogger<PrinterService> logger) =>
        _logger = logger;
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // Do some work to demonstrate starting a hosted service.
        _logger.Log(LogLevel.Information, $"Printer service started.");
        for (int i = 0; i < 25; i++)
        {
            _logger.Log(LogLevel.Information, i.ToString());
            await Task.Delay(TimeSpan.FromMilliseconds(500));
        }
    }
    public Task StopAsync(CancellationToken cancellationToken) {
        _logger.Log(LogLevel.Information, $"Printer service stopped.");
        return Task.CompletedTask;
    }
}
