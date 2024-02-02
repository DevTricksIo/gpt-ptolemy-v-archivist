using ConsoleArchivist.Helpers;
using ConsoleArchivist.Services.Abstractions;
using Microsoft.Extensions.Configuration;

namespace ConsoleArchivist.Services;

public class PharaohBodyBuilderService(IConfiguration configuration) : IPharaohBodyBuilderService
{
    private readonly IConfiguration _configuration = configuration;

    public object BuildGetTranslationBodyRequest(string targetLanguage)
    {
        return new
        {
            model = "gpt-4",
            messages = new List<object>
                {
                new
                {
                    role = "system",
                        content = _configuration.GetSection("Prompt:InstructionForTranslation").Value
                    },
                    new
                    {
                        role = "user",
                        content = targetLanguage
                    }
                }
        };
    }

    public object BuildIsAcceptableTranslationBodyRequest(string yamlTranslation)
    {
        return new
        {
            model = "gpt-4",
            messages = new List<object>
                {
                new
                {
                    role = "system",
                        content = _configuration.GetSection("Prompt:InstructionForReviewing").Value
                    },
                    new
                    {
                        role = "user",
                        content = $"Target language: {TutHelper.GetEnglishLangName(yamlTranslation)}  Content: {yamlTranslation}"
                    }
                }
        };
    }
}
