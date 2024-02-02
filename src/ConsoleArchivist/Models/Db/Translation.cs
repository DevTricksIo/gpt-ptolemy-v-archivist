using System.ComponentModel;

namespace ConsoleArchivist.Models.Db;

public class Translation
{
    public int Id { get; set; }
    public required string TargetLanguage { get; set; }
    public string? LangTag { get; set; }
    public string? GPTTranslationInYaml { get; set; }
    public string? Notes { get; set; }
    public bool IsToSentToGitHub { get; set; }
    public bool InGitHub { get; set; }
    public string? IsAGoodTranslation { get; set; }
}
