namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Castle.DynamicProxy;

    public class Validation : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name != "set_Main")
            {
                IServiceBase service = (IServiceBase)invocation.Proxy;

                service.Validate(invocation.Arguments);
            }

            invocation.Proceed();
        }
    }
}
