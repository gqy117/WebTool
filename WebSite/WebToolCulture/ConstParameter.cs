using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebToolCulture.Resource;

namespace WebToolService
{
    public class ConstParameter
    {
        public const string WebToolUserName = "WebToolUserName";
        public const string WebToolLanguage = "WebToolLanguage";
        public const string SimplifiedChinese = "zh-CN";
        public const string Chinese = "zh";
        public const string English = "en";
        public static List<Language> LanguageList = new List<Language>()
        {
            new Language() { Code = English, Name = UIResource.English,PictureName = "us.png"},
            new Language() { Code = SimplifiedChinese, Name =UIResource.Chinese,PictureName = "cn.png"},
        };
    }
    public class Language
    {
        #region Constructors
        public Language()
        {
        }
        public Language(string code)
        {
            this.Code = code;
            this.Name = ConstParameter.LanguageList.Where(x => x.Code == code).FirstOrDefault().Name;
            this.PictureName = ConstParameter.LanguageList.Where(x => x.Code == code).FirstOrDefault().PictureName;
        }
        #endregion
        #region Properties
        public string Code { get; set; }
        public string Name { get; set; }
        public string PictureName { get; set; }
        #endregion
    }
}
