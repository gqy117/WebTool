﻿namespace WebToolCulture
{
    using System.Linq;

    public class Language
    {
        public Language()
        {
        }

        public Language(string code)
        {
            this.Code = code;
            this.Name = ConstParameter.LanguageList.First(x => x.Code == code).Name;
            this.PictureName = ConstParameter.LanguageList.First(x => x.Code == code).PictureName;
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public string PictureName { get; set; }
    }
}