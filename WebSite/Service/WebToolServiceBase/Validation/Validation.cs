using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;

namespace WebToolService
{
    public class Validation : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name != "set_Main")
            {
                IServiceBase service = invocation.Proxy as IServiceBase;
                service.Validate(invocation.Arguments);
            }
            invocation.Proceed();
        }
    }
}
