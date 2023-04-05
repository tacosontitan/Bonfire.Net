using Retronaut.Net;

namespace ConsoleExample;

public class Program
{
    public static void Main(string[] args) =>
        RetroRuntime.UseStartup<Startup>(args)
                    .Run();
}
