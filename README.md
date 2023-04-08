# ❤️‍🔥 Bonfire.Net

Bonfire.Net is a collection of libraries that make it easy to add hosting and dependency injection to your .NET Framework applications. Say goodbye to boilerplate and hello to a cleaner, more testable codebase.

![License](https://img.shields.io/github/license/tacosontitan/Bonfire.Net?logo=github&style=for-the-badge)

## 💁‍♀️ Getting Started

Get started by reviewing the answers to the following questions:

- [How do I navigate the codebase with confidence?](http://bonfire.tacosontitan.com)
- [How can I help?](./CONTRIBUTING.md)
- [How should I behave here?](./CODE_OF_CONDUCT.md)
- [How do I report security concerns?](./SECURITY.md)

### ✅ Small changes, continuously integrated

Bonfire.Net employs workflows for continuous integration to ensure the repository is held to industry standards; here's the current state of those workflows:

![.NET Workflow](https://img.shields.io/github/actions/workflow/status/tacosontitan/Bonfire.Net/dotnet.yml?label=Build%20and%20Test&logo=dotnet&style=for-the-badge)

### 💎 A few more gems

We believe in keeping the community informed, so here's a few more tidbits of information to satisfy some additional curiosities:

![Contributors](https://img.shields.io/github/contributors/tacosontitan/Bonfire.Net?logo=github&style=for-the-badge)
![Issues](https://img.shields.io/github/issues/tacosontitan/Bonfire.Net?logo=github&style=for-the-badge)
![Stars](https://img.shields.io/github/stars/tacosontitan/Bonfire.Net?logo=github&style=for-the-badge)
![Size](https://img.shields.io/github/languages/code-size/tacosontitan/Bonfire.Net?logo=github&style=for-the-badge)
![Line Count](https://img.shields.io/tokei/lines/github/tacosontitan/Bonfire.Net?logo=github&style=for-the-badge)

## 🔥 Working with Bonfire.Net

The primary objective of Bonfire.Net is to make it easy to add hosting and dependency injection to your .NET Framework applications. To do this, we offer a `static class` called `Ignite` that provides a simple way to bootstrap your application:

```csharp
public static void Main(string[] args) => Ignite.Run();
```

### ⚙️ Configuring the host

The `Ignite` class provides a number of methods that can be used to configure the host. For example, you can configure the host to use a specific startup class:

```csharp
public static void Main(string[] args) =>
    Ignite.UseStartup<Startup>(args)
          .Run();
```

You can also configure the host manually by providing an `Action<IHostBuilder>`:

```csharp
public static void Main() =>
    Ignite.Configure(builder =>
    {
        builder.UseContentRoot(Directory.GetCurrentDirectory());
        builder.UseEnvironment(EnvironmentName.Development);
        builder.UseStartup<Startup>();
    })
    .Run();
```

### ▶️ Creating a `Startup` class

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

## 🖥️ Hosting a Windows service

To run your application as a Windows Service, you'll need to add a reference to the `Bonfire.Hosting.ServiceProcess` package. Then derive from `WindowsService` instead of `ServiceBase`:

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
