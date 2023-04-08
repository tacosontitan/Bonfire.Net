using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleExample;

internal sealed class FibonacciService : IHostedService
{
    private readonly ILogger _logger;
    public FibonacciService(ILogger<FibonacciService> logger) =>
        _logger = logger;
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // Do some work to demonstrate starting a hosted service.
        _logger.Log(LogLevel.Information, $"Fibonacci service started.");
        _logger.Log(LogLevel.Information, $"{{0, 0}}");
        for (int i = 0; i < 40; i++)
        {
            _logger.Log(LogLevel.Information, $"{{{i + 1}, {Fibonacci(i)}}}");
            await Task.Delay(TimeSpan.FromMilliseconds(25));
        }

        // Determines the nth Fibonacci number.
        static int Fibonacci(int n) => n switch
        {
            0 => 1,
            1 => 1,
            _ => Fibonacci(n - 1) + Fibonacci(n - 2)
        };
    }
    public Task StopAsync(CancellationToken cancellationToken) {
        _logger.Log(LogLevel.Information, $"Fibonacci service stopped.");
        return Task.CompletedTask;
    }
}
