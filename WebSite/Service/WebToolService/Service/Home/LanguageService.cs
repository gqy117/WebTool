namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WebToolCulture;

    public class LanguageService : ServiceBase
    {
        #region Methods
        public LanguageModel GetLanguageModel(string languageCode)
        {
            LanguageModel languageModel = new LanguageModel
            {
                CurrentLanguage = this.GetCurrentLanguage(languageCode),
                ListLanguage = this.GetLanguageList(languageCode)
            };

            return languageModel;
        }

        public IList<Language> GetLanguageList(string languageCode)
        {
            return (from language in ConstParameter.LanguageList
                    where language.Code != languageCode
                    select new Language(language.Code)).ToList();
        }

        public Language GetCurrentLanguage(string languageCode)
        {
            return new Language(languageCode);
        }
        #endregion
    }
}