namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IServiceBase
    {
        void Validate(object[] arg);
    }
}