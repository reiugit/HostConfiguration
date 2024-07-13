using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ConfigurationsInConsoleApp;

var host = Host.CreateApplicationBuilder();
{
    host.Services.Configure<Settings>(host.Configuration.GetSection("Settings"));
}

var app = host.Build();
{
    // 1.) Reading the value of a setting via IConfiguration
    var setting1 = app.Services
        .GetRequiredService<IConfiguration>()
        .GetSection("Settings")
        .Get<Settings>()?
        .SettingKey1;

    // 2.) Reading the value of a setting via IOptions
    var setting2 = app.Services
        .GetRequiredService<IOptions<Settings>>()
        .Value
        .SettingKey2;

    // ... the configuration can already be used here before the host is started.
    Console.WriteLine($"\ninfo: Reading settings before host startup.");
    Console.WriteLine($"      Setting 1: '{setting1}'");
    Console.WriteLine($"      Setting 2: '{setting2}'\n");
}

await app.RunAsync();
