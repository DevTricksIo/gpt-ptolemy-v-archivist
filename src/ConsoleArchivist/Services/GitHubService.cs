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

        var payload = new StringContent($"{{\"message\": \"{message}\", \"content\": \"{content}\", \"branch\": \"{branch}\"}}", Encoding.UTF8, "application/json");

        if (!await TranslationExists(langTag))
        {
            var response = await _httpClient.PutAsync($"/src/_translations/{langTag}.md", payload);

            if (response.IsSuccessStatusCode) return true;
        }

        return false;
    }

    private async Task<bool> TranslationExists(string langTag)
    {
        var file = await _httpClient.GetAsync($"/src/_translations/{langTag}.md");

        return file.IsSuccessStatusCode;        
    }
}