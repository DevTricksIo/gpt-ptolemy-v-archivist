using System.ComponentModel;

namespace ConsoleArchivist.Models.Db;

public class Translation
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? LangTag { get; set; }
    public string? GPTTranslationInYaml { get; set; }
    public string? Notes { get; set; }

    [DefaultValue(true)]
    public bool IsToSentToGitHub { get; set; }
    [DefaultValue(false)]
    public bool InGitHub { get; set; }
}
