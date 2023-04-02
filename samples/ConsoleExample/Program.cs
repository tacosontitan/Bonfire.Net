namespace ConsoleExample;

public class Program
{
    public static void Main(string[] args) =>
        Retronaut.UseStartup<Startup>(args)
                 .Run();
}
