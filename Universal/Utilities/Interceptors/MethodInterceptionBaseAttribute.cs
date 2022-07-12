using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.Utilities.Interceptors
{
    #region Comment
    /*
     * Here AttributeTargets means that it will work on Class,Methods and AllowMultiple that it will run in multiple
     * and Inherited means that it will work on inherited classes as well.
     */
    #endregion
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
