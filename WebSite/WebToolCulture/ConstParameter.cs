﻿namespace WebToolCulture
{
    using System.Collections.Generic;
    using Resource;

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
                PictureName = "us"
            },
            new Language()
            {
                Code = SimplifiedChinese, 
                Name = UIResource.Chinese, 
                PictureName = "cn"
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
