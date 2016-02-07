namespace WebToolService
{
    public interface ILanguageService
    {
        LanguageModel GetLanguageModel(string languageCode);
    }
}