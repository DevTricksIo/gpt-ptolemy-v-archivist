using ConsoleArchivist.Services;

namespace ConsoleArchivist;

public class Startup
{
    private readonly IGitHubService _gitHubService;

    public Startup(IGitHubService gitHubService)
    {
        _gitHubService = gitHubService;
    }

    public async Task Run()
    {

        Console.WriteLine("Stating a program!");
    }
}
