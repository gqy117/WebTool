namespace WebToolCulture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using WebToolCulture.Resource;

    public static class ConstParameter
    {
        public const string Chinese = "zh";

        public const string English = "en";

        public const string SimplifiedChinese = "zh-CN";

        public const string WebToolLanguage = "WebToolLanguage";

        public const string WebToolUserName = "WebToolUserName";

        private static IList<Language> languageList = new List<Language>() 
        {
            new Language()
            {
                Code = English, 
                Name = UIResource.English, 
                PictureName = "us.png"
            },
            new Language()
            {
                Code = SimplifiedChinese, 
                Name = UIResource.Chinese, 
                PictureName = "cn.png"
            },
        };

        public static IList<Language> LanguageList
        {
            get
            {
                return languageList;
            }

            set
            {
                languageList = value;
            }
        }
    }
}
