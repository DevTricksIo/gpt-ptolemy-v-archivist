using ConsoleArchivist.Helpers;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ConsoleArchivist.Services;

public class GitHubService(IHttpClientFactory httpClientFactory,
                           IConfiguration configuration) : IGitHubService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("GitHubHTTPClient");
    private readonly IConfiguration _configuration = configuration;

    public async Task<bool> SendTranslation(string yamlTranslation)
    {
        var langTag = TranslationHelper.LangTag(yamlTranslation);
        var message = $"Created {langTag}.md file";
        var content = Convert.ToBase64String(Encoding.UTF8.GetBytes(yamlTranslation));
        var branch = _configuration.GetSection("GitHubConfiguration:Branch").Value;

        var owner = _configuration.GetSection("GitHubConfiguration:Owner").Value;
        var repo = _configuration.GetSection("GitHubConfiguration:Repo").Value;

        var payload = new StringContent($"{{\"message\": \"{message}\", \"content\": \"{content}\", \"branch\": \"{branch}\"}}", Encoding.UTF8, "application/json");

        var path = $"/repos/{owner}/{repo}/contents/src/_translations/{langTag}.md";

        if (!await TranslationExists(path))
        {
            var response = await _httpClient.PutAsync(path, payload);

            if (response.IsSuccessStatusCode) return true;
        }

        return false;
    }

    private async Task<bool> TranslationExists(string path)
    {
        var file = await _httpClient.GetAsync(path);

        return file.IsSuccessStatusCode;        
    }
}