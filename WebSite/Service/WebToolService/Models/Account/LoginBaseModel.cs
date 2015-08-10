namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [Serializable]
    public class LoginBaseModel
    {
        public virtual string UserName
        {
            get;
            set;
        }
    }
}