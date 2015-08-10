namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Utility
    {
        private static AESHelper aesHelper = new AESHelper();

        public static AESHelper AESHelper
        {
            get { return aesHelper; }

            set { aesHelper = value; }
        }
    }
}