using Microsoft.Win32;

namespace PretvornikEnacb;

/// <summary>
/// Utility class for storing and retrieving the API key from the registry.
/// </summary>
internal static class RegistryUtil
{
    private static readonly string registryPath = @"Software\PretvornikEnacb";
    private static readonly string valueName = "ApiKey";

    /// <summary>
    /// Stores the API key in the registry.
    /// </summary>
    /// <param name="apiKey">ApiKey to store.</param>
    public static void StoreApiKey(string apiKey)
    {
        var key = Registry.CurrentUser.CreateSubKey(registryPath);
        key.SetValue(valueName, apiKey);
        key.Close();
    }

    /// <summary>
    /// Retrieves the API key from the registry.
    /// </summary>
    /// <returns>ApiKey string.</returns>
    public static string RetrieveApiKey()
    {
        var key = Registry.CurrentUser.OpenSubKey(registryPath);
        if (key is not null)
        {
            var value = key.GetValue(valueName);
            if (value is not null)
                return value.ToString() ?? string.Empty;

            key.Close();
        }

        return string.Empty;
    }
}
