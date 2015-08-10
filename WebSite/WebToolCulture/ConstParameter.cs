namespace WebToolCulture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using WebToolCulture.Resource;

    public class ConstParameter
    {
        public const string WebToolUserName = "WebToolUserName";

        public const string WebToolLanguage = "WebToolLanguage";

        public const string SimplifiedChinese = "zh-CN";

        public const string Chinese = "zh";

        public const string English = "en";

        private static List<Language> languageList = new List<Language>() 
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

        public static List<Language> LanguageList
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
