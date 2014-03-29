using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebToolService
{
    public interface IServiceBase
    {
        void Validate(object[] arg);
    }
}
