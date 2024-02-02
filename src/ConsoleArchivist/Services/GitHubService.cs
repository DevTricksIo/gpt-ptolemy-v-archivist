using ConsoleArchivist.Helpers;
using System.Text;

namespace ConsoleArchivist.Services;

public class GitHubService : IGitHubService
{
    private readonly HttpClient _httpClient;

    public GitHubService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("GitHubHTTPClient");
    }

    public async Task<bool> SendTranslation(string translationContent)
    {
        var langTag = TranslationHelper.LangTag(translationContent);


        var path = $"src/_translations/{langTag}.md";
        var branch = "a";


        var message = $"Created {langTag}.md file";
        var content = Convert.ToBase64String(Encoding.UTF8.GetBytes(translationContent));

        var githubApiBaseUrl = $"https://api.github.com/repos/abc/123/contents/{path}";
        var payload = new StringContent($"{{\"message\": \"{message}\", \"content\": \"{content}\", \"branch\": \"{branch}\"}}", Encoding.UTF8, "application/json");

        var currentMd = await _httpClient.GetAsync(githubApiBaseUrl);

        if (currentMd.IsSuccessStatusCode)
        {
            Console.WriteLine($"Skipping {langTag}.md - File already exists.");
            return false;
        }
        else
        {
            var response = await _httpClient.PutAsync(githubApiBaseUrl, payload);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"File {langTag}.md created.");
                return true;
            }
            else
            {
                Console.WriteLine($"Failed to create {langTag}.md file : {response.StatusCode}");
                return false;
            }
        }

    }
}