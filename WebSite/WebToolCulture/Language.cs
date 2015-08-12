﻿namespace WebToolCulture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Language
    {
        #region Constructors
        public Language()
        {
        }

        public Language(string code)
        {
            this.Code = code;
            this.Name = ConstParameter.LanguageList.First(x => x.Code == code).Name;
            this.PictureName = ConstParameter.LanguageList.First(x => x.Code == code).PictureName;
        }
        #endregion
        #region Properties
        public string Code { get; set; }

        public string Name { get; set; }

        public string PictureName { get; set; }
        #endregion
    }
}