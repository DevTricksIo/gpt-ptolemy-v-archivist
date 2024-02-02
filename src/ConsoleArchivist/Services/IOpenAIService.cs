namespace ConsoleArchivist.Services
{
    public interface IOpenAIService
    {
        Task<string?> GetTranslation(string prompt);
    }
}
