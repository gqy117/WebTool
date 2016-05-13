namespace WebToolService
{
    using System.Collections.Generic;
    using WebToolCulture;

    public class LanguageModel
    {
        public Language CurrentLanguage { get; set; }

        public IList<Language> ListLanguage { get; set; }
    }
}
