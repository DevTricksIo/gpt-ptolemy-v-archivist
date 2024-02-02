using ConsoleArchivist.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace ConsoleArchivist.Helpers;

public static class ConfigurationExtensions
{
    public static string GetGitHubToken(this IConfiguration configuration)
    {
        var token = configuration.GetSection("GitHubToken")?.Value ?? throw new EmptyContentException("GitHubToken", "GitHub API Authorization Token is missing");

        var pattern = "[a-z]+_[a-z0-9]+";

        Match match = Regex.Match(token, pattern);

        if (match.Success)
        {
            return token;
        }

        throw new ArgumentOutOfRangeException("Your GitHubToken is not a valid token. Please, check your appsetting.json");
    }
}
