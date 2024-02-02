using ConsoleArchivist.Database;
using ConsoleArchivist.Helpers;
using ConsoleArchivist.Services;

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
                .Where(t => t.GPTTranslationInYaml == null || t.IsToSentToGitHub && !t.InGitHub)
                .OrderBy(t => t.Id)
                .Take(3);

            if (!pendingTranslations.Any()) break;

            foreach (var transl in pendingTranslations)
            {
                var content = transl.GPTTranslationInYaml ?? await _openAIService.GetTranslation(prompt: transl.Name);
   
                if (content != null)
                {
                    var langTag = TranslationHelper.GetLangTag(content);
                    transl.GPTTranslationInYaml = content;
                    transl.LangTag = langTag;

                    transl.InGitHub = transl.InGitHub || await _gitHubService.SendTranslation(content);

                }

                _dbContext.SaveChanges();
            }

            Thread.Sleep(TimeSpan.FromMinutes(1));

        } while (true);
    }
}
