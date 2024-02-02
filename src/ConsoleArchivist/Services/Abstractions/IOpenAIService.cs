namespace ConsoleArchivist.Services.Abstractions
{
    public interface IOpenAIService
    {
        Task<string> GetAYamlTranslationBasedOnTemplate(string targetLanguage);
        Task<string> IsAGoodTranslation(string yamlTranslation);
    }
}
