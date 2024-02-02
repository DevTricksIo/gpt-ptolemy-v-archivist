namespace ConsoleArchivist.Services
{
    public interface IGitHubService
    {
        public Task<bool> SendTranslation(string translationContent);
    }
}
