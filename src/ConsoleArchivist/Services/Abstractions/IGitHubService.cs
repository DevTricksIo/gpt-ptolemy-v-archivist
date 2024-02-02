namespace ConsoleArchivist.Services.Abstractions
{
    public interface IGitHubService
    {
        public Task<bool> SendTranslation(string yamlTranslation);
    }
}
