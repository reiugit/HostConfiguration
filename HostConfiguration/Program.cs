using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ConfigurationsInConsoleApp;

var builder = Host.CreateApplicationBuilder();

builder.Services.Configure<Settings>(builder.Configuration.GetSection(nameof(Settings)));

var host = builder.Build();

// 1.) Reading the value of a setting via IConfiguration
var setting1 = host.Services
    .GetRequiredService<IConfiguration>()
    .GetSection(nameof(Settings))
    .Get<Settings>()?
    .SettingKey1;

// 2.) Reading the value of a setting via IOptions
var setting2 = host.Services
    .GetRequiredService<IOptions<Settings>>()
    .Value
    .SettingKey2;

// ... the configuration can already be used here before the host is started.
Console.WriteLine($"\ninfo: Reading settings before host startup.");
Console.WriteLine($"      Setting 1: '{setting1}'");
Console.WriteLine($"      Setting 2: '{setting2}'\n");

await host.RunAsync();
