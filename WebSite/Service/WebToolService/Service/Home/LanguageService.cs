namespace WebToolService
{
    using System.Collections.Generic;
    using System.Linq;
    using WebToolCulture;

    public class LanguageService : ServiceBase, ILanguageService
    {
        public LanguageModel GetLanguageModel(string languageCode)
        {
            LanguageModel languageModel = new LanguageModel
            {
                CurrentLanguage = this.GetCurrentLanguage(languageCode),
                ListLanguage = this.GetLanguageList(languageCode)
            };

            return languageModel;
        }

        private Language GetCurrentLanguage(string languageCode)
        {
            return new Language(languageCode);
        }

        private IList<Language> GetLanguageList(string languageCode)
        {
            return ConstParameter.LanguageList.Where(language => language.Code != languageCode).ToList();
        }
    }
}