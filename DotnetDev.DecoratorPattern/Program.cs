// See https://aka.ms/new-console-template for more information

using DotnetDev.DecoratorPattern;
using Microsoft.Extensions.DependencyInjection;
using SomeSdk;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();

services.AddTransient<SecretsService>();
services.AddTransient<ISecretsService>(x => new CachedSecretsService(x.GetRequiredService<SecretsService>()));

var provider = services.BuildServiceProvider();
var cachedSecretsService = provider.GetService<ISecretsService>();
var secret = cachedSecretsService?.GetSecret("some name");

Console.WriteLine(secret);
