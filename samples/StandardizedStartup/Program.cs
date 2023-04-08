using Bonfire.Hosting;

namespace ConsoleExample;

public class Program
{
    public static void Main(string[] args) =>
        Ignite.UseStartup<Startup>(args)
              .Run();
}
