using System.Collections.Concurrent;
using SomeSdk;

namespace DotnetDev.DecoratorPattern;

public class CachedSecretsService : ISecretsService
{
    private readonly ISecretsService _sealedSecretsService;
    private static readonly ConcurrentDictionary<string, string> Cache = new ();

    public CachedSecretsService(ISecretsService sealedSecretsService)
    {
        _sealedSecretsService = sealedSecretsService;
    }
    
    public string GetSecret(string secretName)
    {
        if (Cache.TryGetValue(secretName, out var cachedSecret))
            return cachedSecret;
        
        //calls the original one, often called the "inner" implementation
        var secret = _sealedSecretsService.GetSecret(secretName);

        Cache.TryAdd(secretName, secret);

        return secret;
    }
}