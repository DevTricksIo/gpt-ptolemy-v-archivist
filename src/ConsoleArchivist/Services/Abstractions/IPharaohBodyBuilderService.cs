namespace ConsoleArchivist.Services.Abstractions;

public interface IPharaohBodyBuilderService
{
    object BuildGetTranslationBodyRequest(string targetLanguage);
    object BuildIsAcceptableTranslationBodyRequest(string yamlTranslation);

}
