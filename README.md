# Ignition.Net

Ignition.Net is a collection of libraries that make it easy to add hosting and dependency injection to your .NET Framework applications. Say goodbye to boilerplate and hello to a cleaner, more testable codebase.

## Using `Ignite`

Working with `Ignite` will simplify the process of creating a new host for your application.

Get started by creating a `Startup` class with a `ConfigureServices` method:

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add services here
    }
}
```

Then, updated the main method in your `Program` class to use `Ignite`:

```csharp
    public static void Main(string[] args) =>
        Ignite.UseStartup<Startup>(args)
              .Run();
```

## Running a Windows Service

To run your application as a Windows Service, you'll need to add a reference to the `Ignition.Net.Framework.ServiceProcess` package. Then derive from `WindowsService` instead of `ServiceBase`:

```csharp
public class MyService : WindowsService
{
    // The rest of your service stays the same.
}
```

Then, update your `Program` class to use `Ignite`:

```csharp
    public static void Main(string[] args) =>
        Ignite.UseStartup<Startup>(args)
              .Run<MyService>();
```
