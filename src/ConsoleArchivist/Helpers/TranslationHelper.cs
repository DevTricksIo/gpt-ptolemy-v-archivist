using ConsoleArchivist.Exceptions;
using System.Text.RegularExpressions;

namespace ConsoleArchivist.Helpers;

public  class TranslationHelper
{
    public static string LangTag(string ymlTranslation)
    {
        _ = ymlTranslation ?? throw new ContentNullException(nameof(ymlTranslation), "The translation cannot be null");
        _ = string.IsNullOrWhiteSpace(ymlTranslation) ? throw new EmptyContentException(nameof(ymlTranslation), "The translation cannot be empty") : string.Empty;

        string pattern = @"langtag:\s*([a-zA-Z-]+)";

        Match match = Regex.Match(ymlTranslation, pattern);

        if (match.Success)
        {
            return match.Groups[1].Value;
        }

        throw new LagTagAbsentException(nameof(ymlTranslation), "No lantag was found in the translation");
    }
}
