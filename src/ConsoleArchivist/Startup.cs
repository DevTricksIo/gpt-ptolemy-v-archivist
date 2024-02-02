using ConsoleArchivist.Database;
using ConsoleArchivist.Helpers;
using ConsoleArchivist.Services.Abstractions;

namespace ConsoleArchivist;

public class Startup(ArchivistDbContext dbContext, IGitHubService gitHubService, IOpenAIService openAIService)
{
    private readonly ArchivistDbContext _dbContext = dbContext;
    private readonly IGitHubService _gitHubService = gitHubService;
    private readonly IOpenAIService _openAIService = openAIService;

    public async Task Run()
    {

        do
        {
            var pendingTranslations = _dbContext.Translations
                .Where(t => t.GPTTranslationInYaml == null || !t.InGitHub)
                .OrderBy(t => t.Id)
                .Take(10);

            if (!pendingTranslations.Any()) break;

            foreach (var pendingTranslation in pendingTranslations)
            {
                var yamlTranslation = pendingTranslation.GPTTranslationInYaml ?? await _openAIService.GetAYamlTranslationBasedOnTemplate(targetLanguage: pendingTranslation.TargetLanguage);
                var isAGoodTranslation = await _openAIService.IsAGoodTranslation(yamlTranslation: yamlTranslation);

                pendingTranslation.LangTag = TutHelper.GetLangTag(yamlTranslation);
                pendingTranslation.GPTTranslationInYaml = yamlTranslation;
                pendingTranslation.IsAGoodTranslation = isAGoodTranslation;

                if (!isAGoodTranslation.Boolify())
                {
                    pendingTranslation.IsToSentToGitHub = false;
                    pendingTranslation.Notes = "I will not send this translation to GitHub because it is a not good translation. " + isAGoodTranslation;
                }
                else if(isAGoodTranslation.Boolify() && pendingTranslation.IsToSentToGitHub)
                {
                   pendingTranslation.InGitHub = await _gitHubService.SendTranslation(yamlTranslation: yamlTranslation);
                }

                _dbContext.SaveChanges();

                Thread.Sleep(TimeSpan.FromMinutes(1));
            }

        } while (true);
    }
}
