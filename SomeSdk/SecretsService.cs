namespace SomeSdk;

public interface ISecretsService
{
    string GetSecret(string secretName);
}

public sealed class SecretsService : ISecretsService
{
    public string GetSecret(string secretName)
    {
        return "a secret";
    }
}