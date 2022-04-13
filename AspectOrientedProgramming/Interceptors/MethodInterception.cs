using AspectOrientedProgramming.AutofacMethodInterceptor;
using Castle.DynamicProxy;

namespace AspectOrientedProgramming.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation,Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            try
            {
                OnBefore(invocation);
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation,e);
                throw;
            }
            finally
            {
                if(isSuccess)
                    OnSuccess(invocation);
            }
            OnAfter(invocation);
        }
    }
}
