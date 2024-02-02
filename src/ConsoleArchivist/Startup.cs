using ConsoleArchivist.Services;

namespace ConsoleArchivist;

public class Startup(IGitHubService gitHubService, IOpenAIService openAIService)
{
    private readonly IGitHubService _gitHubService = gitHubService;
    private readonly IOpenAIService _openAIService = openAIService;

    public async Task Run()
    {

        Console.WriteLine("Stating a program!");
    }
}
