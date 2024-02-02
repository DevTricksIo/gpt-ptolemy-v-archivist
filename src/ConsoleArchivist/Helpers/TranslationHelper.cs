using ConsoleArchivist.Exceptions;
using System.Text.RegularExpressions;

namespace ConsoleArchivist.Helpers;

public  class TranslationHelper
{
    public static string GetLangTag(string yamlTranslation)
    {
        _ = yamlTranslation ?? throw new ContentNullException(nameof(yamlTranslation), "The translation cannot be null");
        _ = string.IsNullOrWhiteSpace(yamlTranslation) ? throw new EmptyContentException(nameof(yamlTranslation), "The translation cannot be empty") : string.Empty;

        string pattern = @"langtag:\s*([a-zA-Z-]+)";

        Match match = Regex.Match(yamlTranslation, pattern);

        if (match.Success)
        {
            return match.Groups[1].Value.Trim();
        }

        throw new KeyAbsentException(nameof(yamlTranslation), "No lantag was found in the translation");
    }

    public static string GetEnglishLangName(string yamlTranslation)
    {

        _ = yamlTranslation ?? throw new ContentNullException(nameof(yamlTranslation), "The translation cannot be null");
        _ = string.IsNullOrWhiteSpace(yamlTranslation) ? throw new EmptyContentException(nameof(yamlTranslation), "The translation cannot be empty") : string.Empty;

        Regex regex = new Regex(@"englishLangName:\s*(.+)");
        Match match = regex.Match(yamlTranslation);

        if (match.Success)
        {
            return match.Groups[1].Value.Trim();
        }

        throw new KeyAbsentException(nameof(yamlTranslation), "No EnglishLangName was found in the translation");

    }
}
