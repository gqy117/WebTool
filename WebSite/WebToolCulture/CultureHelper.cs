namespace WebToolCulture
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Web;

    public static class CultureHelper
    {
        private static Dictionary<string, string> languageDictionary = new Dictionary<string, string>()
        {
            { ConstParameter.Chinese, ConstParameter.SimplifiedChinese },
        };

        public static string GetAnotherLanguage(string lang)
        {
            return lang == null || lang == ConstParameter.English ? ConstParameter.SimplifiedChinese : ConstParameter.English;
        }

        public static string GetLang(string[] userLanguages)
        {
            string lang = ConstParameter.English;

            if (userLanguages != null && userLanguages.Length != 0)
            {
                foreach (string s in userLanguages)
                {
                    if (s.Length >= 2)
                    {
                        string shortLang = s.Substring(0, 2);
                        if (languageDictionary.ContainsKey(shortLang))
                        {
                            lang = languageDictionary[shortLang];
                            break;
                        }
                    }
                }
            }

            return lang;
        }

        public static void SetCurrentCulture(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public static void SetCurrentCulture(string[] userLanguages)
        {
            string lang = GetLang(userLanguages);
            SetCurrentCulture(lang);
        }

        public static void SetCurrentCulture(string lang)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(lang);
            SetCurrentCulture(culture);
        }
    }
}
