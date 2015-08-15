namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WebToolCulture;

    public class LanguageModel
    {
        public Language CurrentLanguage { get; set; }

        public IList<Language> ListLanguage { get; set; }
    }
}
